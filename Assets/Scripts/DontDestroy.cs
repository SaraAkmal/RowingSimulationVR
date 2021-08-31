using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        var musicObj = GameObject.FindGameObjectsWithTag("MusicObject");
        if (musicObj.Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}