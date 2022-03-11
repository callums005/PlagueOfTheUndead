using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public void Retry()
    {
        GameManager.AmendHealth(100 - GameManager.GetHealth(), '+');
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
