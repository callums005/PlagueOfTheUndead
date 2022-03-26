using UnityEngine;
using UnityEngine.InputSystem;

public class DEVOPS : MonoBehaviour
{
    public TMPro.TMP_InputField CmdLine;

    private void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().semicolonKey.wasPressedThisFrame)
        {
            CmdLine.gameObject.SetActive(!CmdLine.gameObject.activeSelf);
            if (CmdLine.gameObject.activeSelf)
            {
                GameManager.SetCursor(LockMode.Confined);
                GameManager.CanUseWeapon = false;
                GameManager.CanMoveCamera = false;
            }
            else
            {
                GameManager.SetCursor(LockMode.Lock);
                GameManager.CanUseWeapon = true;
                GameManager.CanMoveCamera = true;
            }
        }
    }

    public void OnSubmit(string text)
    {
        string[] cmd = text.Split(" ");

        if (cmd.Length < 2)
            return;

        switch(cmd[0].ToUpper())
        {
            case "PLAYERSPEED":
                GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonMovement>().Speed = float.Parse(cmd[1]);
                break;
            case "COINS":
                GameManager.SetCurrency(int.Parse(cmd[1]));
                break;
        }
    }
}