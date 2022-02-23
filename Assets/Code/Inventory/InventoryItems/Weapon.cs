using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon", order = 3)]
public class Weapon : InventoryItem
{
    public int wDamage;
    public float wAttackSpeed;
    public float wCrosshairRange;
    public float wDestroyProjectileTime;
    public WeaponType wType;
    public GameObject wProjectile;

    private float m_NextAttackTime;
    private void OnEnable()
    {
        m_NextAttackTime = Time.time;
    }

    public override Weapon GetWeapon()
    {
        return this;
    }

    public override void Use()
    {
        if (!GameManager.CanUseWeapon)
            return;

        if (Time.time < m_NextAttackTime)
            return;

        switch (wType)
        {
            case WeaponType.Mylee:
                /*
                 This selection of code gets all of the mylee colliders from the weapons object,
                 then checks if any of the mylee colliders has collided, if so it will set colliderData to true
                 with the object it collided with.
                 If the weapon has collided with an enemy, then the enemy will take damage.
                */

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

                if (!colliderData.HasCollided || !colliderData.CollidedObject)
                    return;

                m_NextAttackTime = Time.time + wAttackSpeed;
                if (colliderData.CollidedObject.GetComponent<EnemyCombat>().TakeDamage(wDamage))
                    GameManager.AddXP(5);
                break;
            case WeaponType.Spell:
                m_NextAttackTime = Time.time + wAttackSpeed;
                Instantiate(wProjectile, GameObject.FindGameObjectWithTag("ProjectileSpawn").transform);
                break;
            default:
                Debug.LogError("Unimplemented Error: \"" + wType + "\" not implemented");
                break;
        }
    }
}
