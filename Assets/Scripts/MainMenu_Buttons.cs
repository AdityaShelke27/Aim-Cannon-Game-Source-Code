using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Buttons : MonoBehaviour
{
    public GameObject option;
    public GameObject credits;

    public void Start()
    {
        option.SetActive(false);
        credits.SetActive(false);
    }
    public void start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        option.SetActive(true);
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
