using DG.Tweening;
using UnityEngine;

public class CompassManager : MonoBehaviour
{
    [SerializeField] private GameObject magneticPole;


    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // var rot = transform.localEulerAngles;
        // rot.y += 2;
        // transform.localEulerAngles = rot;
        var lookPos = magneticPole.transform.position - transform.position;
        var lookRot = Quaternion.LookRotation(lookPos, -Vector3.right);
        var eulerY = lookRot.eulerAngles.y;

        var rot = transform.localEulerAngles;
        rot.y = eulerY;
        transform.localEulerAngles = rot;

        // Quaternion rotation = Quaternion.Euler (0, eulerY, 0);
        // transform.rotation = rotation;
    }

    private void rotateToNorth()
    {
        transform.DOLookAt(magneticPole.transform.position, 0.2f, AxisConstraint.Y, Vector3.up)
            .SetEase(Ease.InOutSine);
    }
}