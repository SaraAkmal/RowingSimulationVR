using DG.Tweening;
using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Transform endValue;

    protected float rotationX;
    protected float rotationY;
    protected float rotationZ;

    private void Start()
    {
        rotationZ = transform.localRotation.eulerAngles.z;
        rotationY = transform.localRotation.eulerAngles.y;
        rotationX = transform.localRotation.eulerAngles.x;
        Invoke("Move", 1);
    }

    private void LateUpdate()
    {
    }

    private void Move()
    {
        transform.DOMove(endValue.position, 30).OnComplete(HideObject).SetEase(Ease.InOutSine);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
}