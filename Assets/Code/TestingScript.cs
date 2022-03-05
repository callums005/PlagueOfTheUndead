using UnityEngine;
using UnityEngine.InputSystem;

public class TestingScript : MonoBehaviour
{
    private void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().tKey.wasPressedThisFrame)
        {
            if (GameManager.CharType == CharacterType.Knight)
                GameManager.CharType = CharacterType.Mage;
            else
                GameManager.CharType = CharacterType.Knight;
        }
    }
}
