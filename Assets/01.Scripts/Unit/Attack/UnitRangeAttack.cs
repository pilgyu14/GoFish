using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRangeAttack : UnitAttack
{
    [SerializeField] private BulletScript bulletPrefab;
    [SerializeField] private Transform bulletTransform;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Attack(UnitScript target)
    {
        Animation.AttackAnimation();
        StartCoroutine(AttackCoroutine(target));
    }

    private IEnumerator AttackCoroutine(UnitScript target)
    {
        isCanAttack = false;
        yield return new WaitForSeconds(Data.beforeDelay);
        SummonBullet(target);
        yield return new WaitForSeconds(Data.afterDelay);
        isCanAttack = true;
    }

    protected virtual void SummonBullet(UnitScript target)
    {
        BulletScript obj = PoolManager.Instance.Pop(bulletPrefab) as BulletScript;
        obj.SettingBullet(transform.position, bulletTransform, Data.atkDamage, Data.atkSpeed);
    }
}
