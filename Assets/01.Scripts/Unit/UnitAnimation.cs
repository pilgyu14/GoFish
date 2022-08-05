using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator animator;

    private int hashAttack;
    private int hashDeath;
    private int hashWalk;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hashAttack = Animator.StringToHash("Attack");
        hashDeath = Animator.StringToHash("Death");
        hashWalk = Animator.StringToHash("Walk");
    }

    public void AttackAnimation()
    {
        animator.SetTrigger(hashAttack);
    }

    public void DeathAnimation()
    {
        animator.SetTrigger(hashDeath);
    }

    public void WalkAnimation(float currentSpeed, float maxSpeed)
    {
        animator.SetFloat(hashWalk, currentSpeed / maxSpeed);
    }
}
