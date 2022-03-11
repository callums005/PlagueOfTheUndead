using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public UIManager uiManager;


    private bool m_Debounce = false;

    private void Update()
    {
        if (m_Debounce) return;
        if (!IsInRange()) return;

        m_Debounce = true;

        GenerateCurrencyReward();
        GenerateConsumableReward();
        DestroyChest();
    }

    private void GenerateCurrencyReward()
    {
        GameManager.AmendCurrency((int)Random.Range(50, 200), '+');
    }

    private void GenerateConsumableReward()
    {
        if (Random.Range(0, 3) == 0)
            return;
         
        if (uiManager.invManager.HUDItems[2] != null)
            uiManager.ShowConsumableRewardPopup();
        else
        {
            int consumableReward = Random.Range(0, uiManager.invManager.Consumables.Length);

            uiManager.invManager.SetConsumable(consumableReward);
        }
    }

    private void DestroyChest()
    {
        Destroy(gameObject);
    }
}
