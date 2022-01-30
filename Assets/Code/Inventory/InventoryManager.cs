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

    public void SwitchWeapon()
    {
        Destroy(SelectedItemObject);

        if (SelectedItem == 0)
            SelectedItem = 1;
        else if (SelectedItem == 1)
            SelectedItem = 0;

        SelectedItemObject = Instantiate(HUDItems[SelectedItem].iObject);
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

    public void UseSelectedItem(int attack)
    {
        HUDItems[SelectedItem].Use(attack);
    }

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
                    }
                }
            }
        }
    }
    private void Start()
    {
        SelectedItemObject = Instantiate(HUDItems[SelectedItem].iObject);
        uiManager.UpdateInventoryUI(HUDItems, SelectedItem);
    }
}
