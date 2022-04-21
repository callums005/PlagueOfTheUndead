using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUIManager : MonoBehaviour
{
    public GameObject ControlPannel;
    public GameObject MainMenu;
    public GameObject CharacterSelect;

    public void SelectChacater()
    {
        MainMenu.SetActive(false);
        CharacterSelect.SetActive(true);
    }

    public void StartButton(string type)
    {
        if (type == "Knight")
            GameManager.CharType = CharacterType.Knight;
        else if (type == "Mage")
            GameManager.CharType= CharacterType.Mage;

        GameManager.AmendHealth(100 - GameManager.GetHealth(), '+');
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }


    public void ControlsButton()
    {
        ControlPannel.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        ControlPannel.SetActive(false);
        CharacterSelect.SetActive(false);
        MainMenu.SetActive(true);
    }
}
