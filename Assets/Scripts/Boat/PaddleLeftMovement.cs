using UnityEngine;

public class PaddleLeftMovement : Paddle
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
        var mouseDelta = Input.mousePosition - lastMouseCoordinate;

        if (mouseDelta.Equals(new Vector3(0, 0, 0)))
        {
            RotateToOriginal();
            isRotating = false;
            stopBoatEvent?.Invoke();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            isRotating = true;
            moveBoatEvent?.Invoke();
            ChangeDirection(mouseDelta);
        }

        lastMouseCoordinate = Input.mousePosition;
    }
}