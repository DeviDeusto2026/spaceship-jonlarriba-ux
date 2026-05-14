using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();

        // Útil en el editor para probar el botón
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SolarSystemScene");
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
