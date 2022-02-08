﻿using UnityEngine;

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
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        switch (wType)
        {
            case WeaponType.Blunt:
                MayleeCollider[] colliders = iObject.GetComponents<MayleeCollider>();

                MayleeColliderData colliderData = new MayleeColliderData(false, null);

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

                if (Vector3.Distance(player.transform.position, colliderData.CollidedObject.transform.position) > wRange)
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
