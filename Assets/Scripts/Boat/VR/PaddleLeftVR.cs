using HTC.UnityPlugin.Vive;
using UnityEngine;

public class PaddleLeftVR : Paddle
{
    public Transform movementSource;
    public bool isRotating;
    private Vector3 lastPostion = Vector3.zero;
    private ProcessState nextState;
    private bool resetMovement;

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
        //check if button is pressed get bool value from input source
        var deltaPos = movementSource.localPosition - lastPostion;
        if (deltaPos.Equals(new Vector3(0, 0, 0))) //or (!isPressed && deltaPos.equals(new Vector3(0, 0, 0)))
        {
            isRotating = false;
            RotateToOriginal();
            //stopBoatEvent?.Invoke();
        }
        //updating the movement

        else if (ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Grip))
        {
            // isRotating = true;
            // moveBoatEvent?.Invoke();
            StartRowing(deltaPos);
        }


        // store our mousePosition so that we can check it again next frame.

        lastPostion = movementSource.localPosition;
    }

    protected void StartRowing(Vector3 posDelta)
    {
        if (Mathf.Abs(posDelta.x) > Mathf.Abs(posDelta.y))
        {
            // print("Entered X");
            if (posDelta.x < -0.0001f)
            {
                print("posDelta.x < 0");
                RotateYLeft();
                if (nextState == ProcessState.Back)
                    nextState = ProcessState.up;
            }

            if (posDelta.x > 0.0001f)
            {
                print("posDelta.x > 0");
                RotateYRight();
                if (nextState == ProcessState.Front)
                    nextState = ProcessState.Down;
            }
        }
        else
        {
            // print("Entered Y");
            if (posDelta.y < -0.0001f)
            {
                print("posDelta.y < 0");
                RotateZDown();
                if (nextState == ProcessState.Down)
                    nextState = ProcessState.Back;
            }

            if (posDelta.y > 0.0001f)
            {
                print("posDelta.y > 0");
                RotateZUp();
                if (nextState == ProcessState.up)
                {
                    nextState = ProcessState.Front;
                    print("Rotating");
                    isRotating = true;
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