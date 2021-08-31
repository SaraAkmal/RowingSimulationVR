using DG.Tweening;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    private float rotationX;
    private float xDirectionRotation;

    private void Start()
    {
        rotationX = transform.localRotation.x;
        xDirectionRotation = Random.Range(-0.03f, 0.03f);
        FloatLeft();
    }

    private void Update()
    {
    }

    private void FloatLeft()
    {
        var rot = new Quaternion(rotationX + xDirectionRotation, transform.localRotation.y, transform.localRotation.z,
            transform.localRotation.w);
        transform.DOLocalRotateQuaternion(rot, 2).OnComplete(FloatRight).SetEase(Ease.InOutSine);
    }

    private void FloatRight()
    {
        var rot = new Quaternion(rotationX - xDirectionRotation, transform.localRotation.y, transform.localRotation.z,
            transform.localRotation.w);
        transform.DOLocalRotateQuaternion(rot, 2).OnComplete(FloatLeft).SetEase(Ease.InOutSine);
    }
}