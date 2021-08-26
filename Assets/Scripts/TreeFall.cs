using DG.Tweening;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    [SerializeField] private GameObject palmTree;
    [SerializeField] private Vector3 endValue;
    [SerializeField] private float duration;
    [SerializeField] private GameObject leaves;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Boat")) RotateTree();
    }

    public void RotateTree()
    {
        palmTree.GetComponent<AudioSource>().Play();
        palmTree.transform.DORotate(endValue, duration).SetEase(Ease.OutBounce);
        FallLeaves();
    }

    public void FallLeaves()
    {
        leaves.GetComponent<ParticleSystem>().Play();
    }
}