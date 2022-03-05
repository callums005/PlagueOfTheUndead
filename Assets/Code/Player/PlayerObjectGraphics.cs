using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectGraphics : MonoBehaviour
{
    public GameObject KnightObject;
    public GameObject MageObject;

    private CharacterType m_CurrentCharType;

    private void Update()
    {
        if (m_CurrentCharType != GameManager.CharType)
        {
            if (GameManager.CharType == CharacterType.Knight)
            {
                KnightObject?.SetActive(true);
                MageObject?.SetActive(false);
            }
            else if (GameManager.CharType == CharacterType.Mage)
            {
                KnightObject?.SetActive(false);
                MageObject?.SetActive(true);
            }

            m_CurrentCharType = GameManager.CharType;
        }
    }
}
