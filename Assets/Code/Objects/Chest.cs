using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public InputManager inpManager;
    public UIManager uiManager;
    public GameObject Player;

    public float Radius;

    private bool m_Debounce = false;

    private void Update()
    {
        if (!inpManager.GetUsingState())
            return;

        if (m_Debounce)
            return;

        if (Vector3.Distance(Player.transform.position, transform.position) > Radius)
            return;

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
