using HTC.UnityPlugin.Vive;
using UnityEngine;

public class PaddleRightVR : Paddle
{
    //public InputHelpers.Button inputButton; //button clicked before movement
    public Transform movementSource;
    public bool isRotating;
    public float speed;
    private Vector3 deltaPos;
    private Vector3 lastPostion = Vector3.zero;

    private ProcessState nextState;


    private void Start()
    {
        rotationZ = transform.localRotation.eulerAngles.z;
        rotationY = transform.localRotation.eulerAngles.y;
        rotationX = transform.localRotation.eulerAngles.x;
        nextState = ProcessState.Front;
    }

    // Update is called once per frame
    private void Update()
    {
        deltaPos = (movementSource.localPosition - lastPostion) / Time.deltaTime;
        if (deltaPos.magnitude < 0.3f) //or (!isPressed && deltaPos.equals(new Vector3(0, 0, 0)))
        {
            isRotating = false;
            RotateToOriginal();
            stopBoatEvent?.Invoke();
        }
        //updating the movement

        else if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Grip))
        {
            StartRowing(deltaPos);
        }

        // store our mousePosition so that we can check it again next frame.

        lastPostion = movementSource.localPosition;
    }

    protected void StartRowing(Vector3 posDelta)
    {
        // print("Right:" + posDelta.magnitude);
        if (posDelta.magnitude > speed)
        {
            if (Mathf.Abs(posDelta.x) > Mathf.Abs(posDelta.y))
            {
                if (posDelta.x < 0)
                {
                    //print("posDelta.x < 0");

                    RotateYRight();

                    if (nextState == ProcessState.Back)
                        nextState = ProcessState.up;
                }

                if (posDelta.x > 0)
                {
                    //print("posDelta.x > 0");
                    RotateYLeft();
                    if (nextState == ProcessState.Front) nextState = ProcessState.Down;
                }
            }
            else
            {
                if (posDelta.y < 0)
                {
                    //print("posDelta.y < 0");
                    RotateZDown();
                    if (nextState == ProcessState.Down)
                        nextState = ProcessState.Back;
                }

                if (posDelta.y > 0)
                {
                    //print("posDelta.y > 0");
                    RotateZUp();
                    if (nextState == ProcessState.up)
                    {
                        nextState = ProcessState.Front;
                        moveBoatEvent?.Invoke();
                        isRotating = true;
                    }
                }
            }
        }
    }

    private enum ProcessState
    {
        Front,
        Back,
        Down,
        up
    }
}