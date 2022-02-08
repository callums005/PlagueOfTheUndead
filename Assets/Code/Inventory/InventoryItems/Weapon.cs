using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon", order = 3)]
public class Weapon : InventoryItem
{
    public int wDamage;
    public float wRange;
    public WeaponType wType;

    public override void Use(int attack)
    {
        if (attack == 1)
            Attack1();
        else if (attack == 2)
            Attack2();
    }

    public void Attack1() 
    {
        switch (wType)
        {
            case WeaponType.Blunt:
                MayleeCollider[] colliders = iWorldObject.GetComponentsInChildren<MayleeCollider>();

                MayleeColliderData colliderData = new(false, null);

                foreach (MayleeCollider collider in colliders)
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

    public void Attack2()
    {
    }

}
