using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject Player;

    [Header("Enemy Stats")]
    public double Health;

    [Header("Attack Settings")]
    public int AttackRange;
    public int AttackSpeed;
    public int AttackDamage;

    private float m_NextAttackTime;

    private void Update()
    {
        IsEnemyDead();
        Attack(); 
    }

    private void IsEnemyDead()
    {
        if (Health <= 0)
            Destroy(transform.parent.gameObject);
    }

    private void Attack()
    {
        if (Time.time < m_NextAttackTime)
            return;
        if (Vector3.Distance(transform.position, Player.transform.position) > AttackRange)
            return;

        m_NextAttackTime = Time.time + AttackSpeed;
        // TODO: Attack
        GameManager.AmendHealth(AttackDamage, '-');
    }
}
