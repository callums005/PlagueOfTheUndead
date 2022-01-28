using UnityEngine;

public enum ItemType { Weapon, Consumable, Shield }

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class InventoryItem : ScriptableObject
{
    public string iName;
    public Sprite iSprite;
    public GameObject iObject;
    public CharacterType iCharacterType;
    public ItemType iType;

    public virtual void Use() { throw new System.NotImplementedException(); }
}
