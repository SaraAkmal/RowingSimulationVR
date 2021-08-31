using DG.Tweening;
using HTC.UnityPlugin.Vive;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField] public float xDirectionRotation;
    [SerializeField] public float yDirectionPosition;
    [SerializeField] private float rotateSpeed = 0.5f;
    [SerializeField] private GameObject boatParent;
    private bool isBoatNotFloating;
    private bool leftPaddleRotating;
    private bool rightPaddleRotating;
    private float rotationX;


    private void Start()
    {
        rotationX = transform.localRotation.x;
        MoveUp();
        FloatLeft();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        xDirectionRotation = Random.Range(0.01f, 0.015f);
        rightPaddleRotating = transform.Find("PaddleRight").GetComponent<PaddleRightVR>().isRotating;
        leftPaddleRotating = transform.Find("PaddleLeft").GetComponent<PaddleLeftVR>().isRotating;

        if (ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Grip) && leftPaddleRotating &&
            !ViveInput.GetPress(HandRole.RightHand, ControllerButton.Grip))
        {
            RotateLeftBoat(); //positive rotate speed value
            isBoatNotFloating = true;
        }

        else if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Grip) && rightPaddleRotating &&
                 !ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Grip))
        {
            RotateRightBoat(); //negative rotate speed value
            isBoatNotFloating = true; //flag for the whole boat rotating
        }
    }

    private void RotateLeftBoat()
    {
        boatParent.transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void RotateRightBoat()
    {
        boatParent.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }


    private void MoveUp()
    {
        transform.DOMoveY(transform.position.y + yDirectionPosition, 3)
            .OnComplete(MoveDown).SetEase(Ease.InOutSine);
    }

    private void MoveDown()
    {
        transform.DOMoveY(transform.position.y - yDirectionPosition, 3)
            .OnComplete(MoveUp).SetEase(Ease.InOutSine);
    }

    private void FloatLeft()
    {
        var rot = new Quaternion(rotationX + xDirectionRotation, transform.localRotation.y, transform.localRotation.z,
            transform.localRotation.w);
        transform.DOLocalRotateQuaternion(rot, 2).OnComplete(FloatRight).SetEase(Ease.InOutSine).SetId("Float");
    }

    private void FloatRight()
    {
        var rot = new Quaternion(rotationX - xDirectionRotation, transform.localRotation.y, transform.localRotation.z,
            transform.localRotation.w);
        transform.DOLocalRotateQuaternion(rot, 2).OnComplete(FloatLeft).SetEase(Ease.InOutSine).SetId("Float");
    }
}