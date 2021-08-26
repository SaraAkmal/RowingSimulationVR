using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _speed;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}