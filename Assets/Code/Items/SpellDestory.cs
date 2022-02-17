using UnityEngine;

public class SpellDestory : MonoBehaviour
{
    private void Start()
    {
        InventoryManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InventoryManager>();

        if (manager == null)
            return;

        Weapon selectedItem = manager.HUDItems[manager.SelectedItem].GetWeapon();
        float time = selectedItem.wDestroyProjectileTime;

        if (time <= 0)
            Debug.LogWarning("Spell's wTime is set to <= 0. The object will be destroyed when spawned.");

        Destroy(gameObject, time);
    }
}