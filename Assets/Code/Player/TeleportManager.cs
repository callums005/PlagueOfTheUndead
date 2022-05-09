using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    public string NextLevelName;
    public int RequiredXP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;



        if (GameManager.GetXP() >= RequiredXP)
        {
            GameManager.NextScene = NextLevelName;
            if (SceneManager.GetActiveScene().name != "Forrest")
                SceneManager.LoadScene("Shop", LoadSceneMode.Single);
            else
                SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);
        }
            
    }
}
