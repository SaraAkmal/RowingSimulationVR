using DG.Tweening;
using UnityEngine;

public class CaveAmbience : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Boat"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().DOFade(1, 2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("Boat")) gameObject.GetComponent<AudioSource>().DOFade(0, 2).OnComplete(StopAudio);
    }

    private void StopAudio()
    {
        gameObject.GetComponent<AudioSource>().Pause();
    }
}