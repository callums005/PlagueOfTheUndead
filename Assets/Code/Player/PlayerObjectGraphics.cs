using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectGraphics : MonoBehaviour
{
    public GameObject KnightObject;
    public GameObject MageObject;

    public Animator KnightAnimator;
    public Animator MageAnimator;
    public Animator HandAnimator;

    public InventoryManager InventoryManager;

    private CharacterType m_CurrentCharType;

    private void Update()
    {
        if (InventoryManager.HUDItems[InventoryManager.SelectedItem] != null)
        {
            if (GameManager.CharType == CharacterType.Knight)
                KnightAnimator.SetBool("HasWeapon", true);
            else if (GameManager.CharType == CharacterType.Mage)
                MageAnimator.SetBool("HasWeapon", true);
        }
        else
        {
            if (GameManager.CharType == CharacterType.Knight)
                KnightAnimator.SetBool("HasWeapon", false);
            else if (GameManager.CharType == CharacterType.Mage)
                MageAnimator.SetBool("HasWeapon", false);
        }

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

    public void UseWeaponAttackAnimation()
    {
        HandAnimator.SetTrigger("Attack");
    }

}
