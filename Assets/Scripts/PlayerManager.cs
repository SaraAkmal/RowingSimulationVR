using DG.Tweening;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private StartWave waveScript;
    [SerializeField] private Transform roomPos;
    [SerializeField] private GameObject fadeHandler;
    [SerializeField] private AudioSource shipSound;
    public GameObject oceanScene;

    public GameObject roomScene;

    //private GDTFadeEffect fadeScript;
    private bool invokeMethod = true;


    private void Start()
    {
        //waveScript.fadeEvent = FadeIn;
        //fadeScript = fadeHandler.GetComponent<GDTFadeEffect>();
    }


    private void FadeIn()
    {
        //fadeScript.StartEffect();
        Invoke(nameof(ChangeScenes), 1);
    }

    private void ChangeScenes()
    {
        if (invokeMethod)
        {
            oceanScene.transform.Find("Boat").GetComponent<BoatManager>().enabled = false;
            roomScene.SetActive(true);
            GetComponent<FollowTarget>().enabled = false;
            gameObject.transform.position = roomPos.position;
            gameObject.transform.rotation = roomPos.rotation;
            shipSound.volume = 0;
            shipSound.Play();
            shipSound.DOFade(0.8f, 10);
            Invoke(nameof(FadeOut), 1);
            print("changeScenes method");
            invokeMethod = false;
        }
    }

    private void FadeOut()
    {
        // fadeScript.goingToLast = false;
        // fadeScript.currentValue = 0; // sudden effect
        // fadeScript.StartEffect();
    }
}