using UnityEngine;

public class EnemyCombat : AudioInterface
{
    [Space()]
    public GameObject Player;
    public GameObject EnemyGFX;
    public EnemyAnimationManager AnimationManager;

    [Header("Enemy Stats")]
    public double Health;

    [Header("Attack Settings")]
    public float AttackRange;
    public int AttackSpeed;
    public int AttackDamage;

    private bool DeathSoundDebouce = false;

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
        if (!IsEnemyDead())
            Attack(); 
    }

    private bool IsEnemyDead()
    {
        if (Health <= 0)
        {
            EnemyGFX.SetActive(false);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            
            if (!DeathSoundDebouce)
            {
                PlayAudio();
                DeathSoundDebouce = true;
            }

            Destroy(transform.parent.gameObject, Source.clip.length);

            return true;
        }

        return false;
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

        AnimationManager.AttackAnimation(true);
        m_NextAttackTime = Time.time + AttackSpeed;
        // TODO: Attack
        GameManager.AmendHealth((Health > Health / 4) ? AttackDamage : AttackDamage / 2, '-');
        Invoke("EndAttack", AttackSpeed);
    }

    private void EndAttack()
    {
        AnimationManager.AttackAnimation(false);
    }
}
