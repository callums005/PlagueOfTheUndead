using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Inventory/Consumable", order = 2)]
public class Consumable : InventoryItem
{
    public float cValue;
    public ConsumableType cType;


    public override void Use() 
    {
        switch (cType)
        {
            case ConsumableType.Healing:
                GameManager.AmendHealth((int)cValue, '+');
                break;
            case ConsumableType.LifeBottle:
                GameManager.AmendHealth(100 - GameManager.GetHealth(), '+');
                break;
            default:
                Debug.LogError("Unimplemented Error: \"" + cType + "\" not implemented");
                break;
        }
    }
}
