using UnityEngine;

public class FogManager : MonoBehaviour
{
    [SerializeField] private GameObject dust;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Boat")) StartDust();
    }

    private void StartDust()
    {
        dust.GetComponent<ParticleSystem>().Play();
    }
}