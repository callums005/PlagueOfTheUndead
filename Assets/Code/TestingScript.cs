using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingScript : MonoBehaviour
{
    public TMPro.TMP_Text m_Text;

    // Update is called once per frame
    void Update()
    {
        m_Text.SetText((1.0f / Time.smoothDeltaTime).ToString());

        if (InputSystem.GetDevice<Keyboard>().rKey.wasPressedThisFrame)
        {
            GameManager.AmendHealth(25, '-');
        }
        if (InputSystem.GetDevice<Keyboard>().eKey.wasPressedThisFrame)
        {
            GameManager.AmendHealth(25, '+');
        }

        if (InputSystem.GetDevice<Keyboard>().xKey.wasPressedThisFrame)
        {
            GameManager.AddXP(10);
        }
    }
}
