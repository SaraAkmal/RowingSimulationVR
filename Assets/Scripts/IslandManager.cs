using UnityEngine;

public class IslandManager : MonoBehaviour
{
    [SerializeField] private GameObject vrPlayer;


    private void OnTriggerEnter(Collider other)
    {
        print("trigger");
        if (other.gameObject.name == "Boat")
        {
            print("Boat");
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.GetComponent<BoatManager>().enabled = false;
            vrPlayer.transform.SetParent(null);
        }
    }
}