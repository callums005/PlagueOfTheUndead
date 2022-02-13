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

        SelectedItemObject = Instantiate(HUDItems[SelectedItem].iObject);
        HUDItems[SelectedItem].iWorldObject = SelectedItemObject;
        uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
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
        HUDItems[SelectedItem].Use();
    }

    /// <summary>
    /// Sets item to the correct inventory slot
    /// </summary>
    /// <param name="item">InventoryItem: Item to add</param>
    /// <param name="slot">int: Slot to add the item to</param>

    public void SetItem(InventoryItem item, int slot)
    {
        if (item != null)
        {
            if (item.iCharacterType == GameManager.CharType || item.iCharacterType == CharacterType.Any)
            {
                if (slot == 2 && item.iType == ItemType.Consumable)
                    HUDItems[slot] = item;
                if (slot == 3 && item.iType == ItemType.Shield) throw new System.NotImplementedException();
                // TODO: Shield
                if ((slot == 0 || slot == 1) && item.iType == ItemType.Weapon)
                {
                    HUDItems[slot] = item;

                    if (slot == SelectedItem)
                    {
                        Destroy(SelectedItemObject);
                        SelectedItemObject = Instantiate(HUDItems[slot].iObject);
                        HUDItems[slot].iWorldObject = SelectedItemObject;
                    }
                }
            }
        }
    }
    private void Start()
    {
        SelectedItemObject = Instantiate(HUDItems[SelectedItem].iObject);
        HUDItems[SelectedItem].iWorldObject = SelectedItemObject;
        uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
    }
}
