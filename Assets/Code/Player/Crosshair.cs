using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public GameObject Player;
    public InventoryManager InventoryManager;
    public CombatManager CombatManager;
    public Image CrosshairImage;

    private GameObject nearestEnemy;

    private void Update()
    {
        Weapon weapon = InventoryManager.HUDItems[InventoryManager.SelectedItem].GetWeapon();

        nearestEnemy = CombatManager.GetNearestEnemy().transform.Find("Agent").gameObject;

        if (Vector3.Distance(nearestEnemy.transform.position, Player.transform.position) <= weapon.wCrosshairRange)
        {
            Debug.Log("True");
            transform.position = nearestEnemy.transform.position + new Vector3(0, 2, 0);
            CrosshairImage.enabled = true;
        }
        else
        {
            CrosshairImage.enabled = false;
        }
    }
}