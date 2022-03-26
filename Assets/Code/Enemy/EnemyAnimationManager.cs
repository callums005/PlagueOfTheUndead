using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    public Animator _Animator;

    public void AttackAnimation(bool isAttack)
    {
        Debug.Log("Setting state: " + isAttack);
        _Animator.SetBool("Attack", isAttack);
    }
}
