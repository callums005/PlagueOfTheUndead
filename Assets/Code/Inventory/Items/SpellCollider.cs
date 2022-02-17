using System;
using System.Collections;
using UnityEngine;

public class SpellCollider : MonoBehaviour
{
    private int m_Damage;

    /// <summary>
    /// This function gets the damage from the weapon that it was spawned by
    /// </summary>
    private void Start()
    {
        InventoryManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InventoryManager>();

        if (manager == null)
            return;

        Weapon selectedItem = manager.HUDItems[manager.SelectedItem].GetWeapon();
        m_Damage = selectedItem.wDamage;
    }

    /// <summary>
    /// Unlike the mylee collider, the spell collider damages the enemy independent of if the weapon was used.
    /// When the weapon is used it will spawn a spell, after that there is no link between the spell and the weapon.
    /// For this reason, the spell's hit detection and hit damage code must be independent of the weapon.
    /// When the spell collides with an enemy, the enemy will take damage and the spell will be deleted
    /// 
    /// If the arrow hits anything, it will be deleted after a few seconds
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ThirdPersonCharacter")
            return;

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemyCombat>().TakeDamage(m_Damage))
                GameManager.AddXP(5);

        }

        Destroy(transform.parent.gameObject);
    }
}