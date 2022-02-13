using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon", order = 3)]
public class Weapon : InventoryItem
{
    public int wDamage;
    public float wRange;
    public WeaponType wType;

    public override void Use()
    {
        switch (wType)
        {
            case WeaponType.Blunt:
                MyleeCollider[] colliders = iWorldObject.GetComponentsInChildren<MyleeCollider>();

                MyleeColliderData colliderData = new(false, null);

                foreach (MyleeCollider collider in colliders)
                {

                    if (collider.GetColliderData().HasCollided)
                    {
                        colliderData.HasCollided = true;
                        colliderData.CollidedObject = collider.GetColliderData().CollidedObject;
                    }
                }

                if (!colliderData.HasCollided)
                    return;

                colliderData.CollidedObject.GetComponent<EnemyCombat>().TakeDamage(wDamage);
                break; 
            default:
                Debug.LogError("Unimplemented Error: \"" + iName + "\" has no Attack1 implemented");
                break;
        }
    }
}
