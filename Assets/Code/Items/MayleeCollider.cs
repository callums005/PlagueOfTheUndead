using UnityEngine;

public class MayleeCollider : MonoBehaviour
{
    private bool HasCollided = false;
    private GameObject CollidedEnemy = null;

    public MayleeColliderData GetColliderData()
    {
        return new MayleeColliderData(HasCollided, CollidedEnemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
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