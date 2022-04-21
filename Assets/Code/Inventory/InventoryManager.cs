using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Items")]
 
    public InventoryItem[] HUDItems = new InventoryItem[3] { null, null, null };
    /*
        [0]: Primary
        [1]: Secondary
        [2]: Consumable
        [3]: Shield
    */
    public int SelectedItem;
    private GameObject SelectedItemObject;

    [Space()]
    public UIManager uiManager;

    [Header("List of Items")]
    public Weapon[] Weapons;
    public Consumable[] Consumables;

    /// <summary>
    /// Switches weapon and creates gameobject in player hand depending on the item
    /// </summary>
    public void SwitchWeapon()
    {
        Destroy(SelectedItemObject);

        if (SelectedItem == 0)
            SelectedItem = 1;
        else if (SelectedItem == 1)
            SelectedItem = 0;

        if (HUDItems[SelectedItem] != null)
        {
            SelectedItemObject = Instantiate(HUDItems[SelectedItem].iObject);
            HUDItems[SelectedItem].iWorldObject = SelectedItemObject;
            uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
        }
    }

    public void UseConsumable()
    {
        if (HUDItems[2] != null)
        {
            HUDItems[2].Use();
            HUDItems[2] = null;

            uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
        }
    }

    public void UseSelectedItem()
    {
        if (HUDItems[SelectedItem] != null)
            HUDItems[SelectedItem].Use();
    }

    /// <summary>
    /// Sets item to the correct inventory slot
    /// </summary>
    /// <param name="item">InventoryItem: Item to add</param>
    /// <param name="slot">int: Slot to add the item to</param>

    public void SetWeapon(int item, int slot)
    {
        if (Weapons[item].iCharacterType != GameManager.CharType && Weapons[item].iCharacterType != CharacterType.Any)
            return;

        if (slot != 0 && slot != 1)
            return;

        HUDItems[slot] = Weapons[item];

        if (slot == SelectedItem)
        {
            Destroy(SelectedItemObject);
            SelectedItemObject = Instantiate(HUDItems[slot].iObject);
            HUDItems[slot].iWorldObject = SelectedItemObject;
        }

        uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
    }

    public void SetConsumable(int item)
    {
        if (Consumables[item].iCharacterType != GameManager.CharType && Consumables[item].iCharacterType != CharacterType.Any)
            return;

        HUDItems[2] = Consumables[item];

        uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
    }

    private void Start()
    {
        string[] items = GameManager.PurchasedItems.ToArray();

        int slot = 0;

        for (int k=0; k < items.Length; k++)
        {
            for (int j=0; j < Weapons.Length; j++)
            {
                if (items[k] == Weapons[j].iName)
                {
                    SetWeapon(j, slot);
                    slot++;
                }
            }

            for (int l=0; l < Consumables.Length; l++)
            {
                if (items[k] == Consumables[l].iName)
                {
                    SetConsumable(l);
                }
            }
        }

        for (int i=0; i < HUDItems.Length; i++)
        {
            if (HUDItems[i] == null)
                continue;

            if (HUDItems[i].iCharacterType == CharacterType.Any)
                continue;

            if (HUDItems[i].iCharacterType != GameManager.CharType)
            {
                HUDItems[i] = null;
            }
        }

        if (HUDItems[SelectedItem] != null)
        {
            SelectedItemObject = Instantiate(HUDItems[SelectedItem].iObject);
            HUDItems[SelectedItem].iWorldObject = SelectedItemObject;
            uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
        }
    }
}
