using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMeleeAttack : UnitAttack
{
    public override void Attack(UnitScript target)
    {
        if (!isCanAttack) return;
        Animation.AttackAnimation();
        StartCoroutine(AttackCoroutine(target));
    }

    private IEnumerator AttackCoroutine(UnitScript target)
    {
        isCanAttack = false;
        yield return new WaitForSeconds(Data.beforeDelay);
        if (target != null)
            target.GetHit(Data.atkDamage);
        else
            GameManager.Instance.FishHomeHP(Data.atkDamage);
        yield return new WaitForSeconds(Data.beforeDelay);
        isCanAttack = true;
    }
}
