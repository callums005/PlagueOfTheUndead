using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon", order = 3)]
public class Weapon : InventoryItem
{
    public int Damage;
    public float Range;

    public override void Use()
    {
        Debug.Log("Using weapon");
    }
}
