using System;
using DG.Tweening;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float offset = 20;
    [SerializeField] private float duration = 0.5f;
    public Action moveBoatEvent;

    protected float rotationX;
    protected float rotationY;
    protected float rotationZ;
    public Action stopBoatEvent;

    private void Start()
    {
        DOTween.SetTweensCapacity(2000, 100);
    }

    protected void RotateZDown()
    {
        transform.DOLocalRotate(
                new Vector3(rotationX, rotationY, rotationZ - offset + 20), duration)
            .SetEase(Ease.InOutSine);
    }

    protected void RotateZUp()
    {
        transform.DOLocalRotate(
                new Vector3(rotationX, rotationY, rotationZ + offset - 20), duration)
            .SetEase(Ease.InOutSine);
    }

    protected void RotateYRight()
    {
        transform.DOLocalRotate(
                new Vector3(rotationX, rotationY + offset, rotationZ), duration)
            .SetEase(Ease.InOutSine);
    }

    protected void RotateYLeft()
    {
        transform.DOLocalRotate(
                new Vector3(rotationX, rotationY - offset, rotationZ), duration)
            .SetEase(Ease.InOutSine);
    }

    protected void RotateToOriginal()
    {
        transform.DOLocalRotate(
                new Vector3(rotationX, rotationY, rotationZ), 2)
            .SetEase(Ease.InOutSine);
    }

    protected void ChangeDirection(Vector3 posDelta)
    {
        if (posDelta.x < 0)
        {
            print("posDelta.x < 0");
            RotateYLeft();
        }

        if (posDelta.x > 0)
        {
            print("posDelta.x > 0");
            RotateYRight();
        }

        if (posDelta.y < 0)
        {
            print("posDelta.y < 0");
            RotateZDown();
        }

        if (posDelta.y > 0)
        {
            print("posDelta.y > 0");
            RotateZUp();
        }
    }
}