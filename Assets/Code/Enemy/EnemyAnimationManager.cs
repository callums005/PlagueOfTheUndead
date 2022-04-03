using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    public Animator _Animator;

    public void AttackAnimation(bool isAttack)
    {
        _Animator.SetBool("Attack", isAttack);
    }

    public void WalkAnimation(bool isRunning)
    {
        _Animator.SetBool("Walking", isRunning);
    }
}
