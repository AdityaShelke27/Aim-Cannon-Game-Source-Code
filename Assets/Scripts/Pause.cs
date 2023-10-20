using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Option;
    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Cannon.isPaused = false;
    }

    public void Options()
    {
        Option.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Cannon.Round = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
