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
    private void OnEnable()
    {
        m_NextAttackTime = Time.time;
    }
    public bool TakeDamage(double Amount)
    {
        Health -= Amount;

        if (Health <= 0)
            return true;
        else
            return false;
    }

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

    /// <summary>
    /// This function calculates how long it has been since the last attack, if it is greater than
    /// the attack speed plus the time of the last attack then it will attack the player if in range and
    /// reset the timer
    /// </summary>
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
