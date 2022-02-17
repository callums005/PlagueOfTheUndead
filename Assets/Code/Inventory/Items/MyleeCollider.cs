using UnityEngine;

public class MyleeCollider : MonoBehaviour
{
    private bool HasCollided = false;
    private GameObject CollidedEnemy = null;

    public MyleeColliderData GetColliderData()
    {
        return new MyleeColliderData(HasCollided, CollidedEnemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
            return;

        HasCollided = true;
        CollidedEnemy = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != CollidedEnemy)
            return;

        HasCollided = false;
        CollidedEnemy = null;
    }
}