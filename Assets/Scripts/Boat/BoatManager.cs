using HTC.UnityPlugin.Vive;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject boatParent;

    private bool myBool;

    public bool isMoving
    {
        get => myBool;
        set
        {
            if (value == myBool)
                return;

            myBool = value;
            if (myBool)
                GetComponent<AudioSource>().Play();
            else
                GetComponent<AudioSource>().Pause();
        }
    }

    private void Start()
    {
        var paddleRight = transform.Find("PaddleRight");
        paddleRight.GetComponent<PaddleRightVR>().moveBoatEvent = MoveBoat;
        paddleRight.GetComponent<PaddleRightVR>().stopBoatEvent = StopBoat;
        var paddleLeft = transform.Find("PaddleLeft");
        paddleLeft.GetComponent<PaddleLeftVR>().moveBoatEvent = MoveBoat;
        paddleLeft.GetComponent<PaddleLeftVR>().stopBoatEvent = StopBoat;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        boatParent.transform.position += transform.forward * Time.deltaTime * speed;
        if (isMoving &&
            ViveInput.GetPress(HandRole.RightHand,
                ControllerButton.Grip))
        {
        } //&& ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Grip) 
    }


    private void MoveBoat()
    {
        isMoving = true;
        print(isMoving);
    }

    private void StopBoat()
    {
        isMoving = false;
        print(isMoving);
    }
}