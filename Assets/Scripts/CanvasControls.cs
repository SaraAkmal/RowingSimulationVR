using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControls : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}