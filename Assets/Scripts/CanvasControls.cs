using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControls : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1;

    public void ChangeScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.enabled = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}