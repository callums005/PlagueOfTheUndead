using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ShopUIManager : MonoBehaviour
{
    public TMPro.TMP_Text CurrencyText;
    public TMPro.TMP_Text ErrorText;

    public GameObject KnightShop;
    public GameObject MageShop;

    private int weaponCount;
    private int consumableCount;

    private void Start()
    {
        if (GameManager.CharType == CharacterType.Knight)
        {
            MageShop.SetActive(false);
            KnightShop.SetActive(true);
        }
        else if (GameManager.CharType == CharacterType.Mage)
        {
            MageShop.SetActive(true);
            KnightShop.SetActive(false);
        }

        GameManager.PurchasedItems = new List<string>();
    }


    private void Update()
    {
        CurrencyText.SetText(GameManager.GetCurrency().ToString());
    }

    public void PurchaseItem(InventoryItem item)
    {
        if (GameManager.PurchasedItems.Contains(item.iName))
        {
            ErrorText.SetText("You already own this item.");
            ErrorText.gameObject.SetActive(true);
            return;
        }
        else
        {
            if (GameManager.GetCurrency() >= item.iCost)
            {
                switch (item.iType)
                {
                    case ItemType.Weapon:
                        if (weaponCount > 1)
                        {
                            ErrorText.SetText("You have purchased the maximum number of weapons.");
                            ErrorText.gameObject.SetActive(true);
                            return;
                        }
                        weaponCount++;
                        break;
                    case ItemType.Consumable:
                        if (consumableCount > 0)
                        {
                            ErrorText.SetText("You have purchased the maximum number of consumables.");
                            ErrorText.gameObject.SetActive(true);
                            return;
                        }
                        consumableCount++;
                        break;
                }


                ErrorText.gameObject.SetActive(false);
                GameManager.AmendCurrency(item.iCost, '-');
                GameManager.PurchasedItems.Add(item.iName);
            }
            else
            {
                ErrorText.SetText("You do not have enough coins.");
                ErrorText.gameObject.SetActive(true);
                return;
            }
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Graveyard", LoadSceneMode.Single);
    }
}