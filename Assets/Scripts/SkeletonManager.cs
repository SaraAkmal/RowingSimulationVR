using UnityEngine;

public class SkeletonManager : MonoBehaviour
{
    [SerializeField] private AudioClip woodAudioClip;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Boat" || other.gameObject.name == "BoatParent")
        {
            print("playBoat");
            gameObject.GetComponent<AudioSource>().clip = woodAudioClip;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SphereCollider")
        {
            gameObject.transform.SetParent(null);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "map")
        {
            other.gameObject.transform.SetParent(null);
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}