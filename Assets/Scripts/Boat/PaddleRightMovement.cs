using UnityEngine;

public class PaddleRightMovement : Paddle
{
    public bool isRotating;
    private Vector3 lastMouseCoordinate = Vector3.zero;

    private void Start()
    {
        rotationZ = transform.localRotation.eulerAngles.z;
        rotationY = transform.localRotation.eulerAngles.y;
        rotationX = transform.localRotation.eulerAngles.x;
    }

    // Update is called once per frame
    private void Update()
    {
        // How much it has moved, by comparing it with the stored coordinate.
        var mouseDelta = Input.mousePosition - lastMouseCoordinate;

        if (mouseDelta.Equals(new Vector3(0, 0, 0)))
        {
            isRotating = false;
            RotateToOriginal();
            stopBoatEvent?.Invoke();
        }
        else if (Input.GetKey(KeyCode.V))
        {
            isRotating = true;
            moveBoatEvent?.Invoke();
            ChangeDirection(mouseDelta);
        }

        // store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
    }
}