using UnityEngine;

[CreateAssetMenu(fileName = "HealthConsumable", menuName = "Inventory/HealthConsumable", order = 2)]
public class HealthConsumable : InventoryItem
{
    public int HealthIncrease;

    public override void Use() 
    {
        GameManager.AmendHealth(HealthIncrease, '+');
    }
}
