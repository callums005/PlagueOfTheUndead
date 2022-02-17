using System;
using System.Collections;
using UnityEngine;

public class SpellCollider : MonoBehaviour
{
    public Rigidbody RB;

    private int m_Damage;
    private void Start()
    {
        InventoryManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InventoryManager>();

        if (manager == null)
            return;

        Weapon selectedItem = manager.HUDItems[manager.SelectedItem].GetWeapon();
        m_Damage = selectedItem.wDamage;
    }

    /// <summary>
    /// Unlike the mylee collider, the arrow collider damages the enemy independent of if the weapon was used.
    /// When the weapon is used it will fire an arrow, after that there is no link between the arrow and the weapon.
    /// For this reason, the arrow's hit detection and hit damage code must be independent of the arrow.
    /// When the arrow collides with an enemy, the enemy will take damage and the arrow will be deleted
    /// 
    /// If the arrow hits anything, it will be deleted after a few seconds
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ThirdPersonCharacter")
            return;

        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<EnemyCombat>().TakeDamage(m_Damage);

        RB.velocity = Vector3.zero;
        RB.angularVelocity = Vector3.zero;
        RB.isKinematic = true;

        Destroy(transform.parent.gameObject);
    }
}