using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : PoolableObject
{
    [SerializeField] protected UnitDataSO unitData;
    public UnitDataSO UnitData => unitData;

    [SerializeField] protected UnitAI unitAI;
    public UnitAI AI => unitAI;

    [SerializeField] protected UnitAnimation unitAnimation;
    public UnitAnimation Animation => unitAnimation;

    [SerializeField] protected UnitAttack unitAttack;
    public UnitAttack UnitAttack => unitAttack;


    #region 현재상태
    protected float currentHP = 0;
    protected float currentSpeed = 0;
    private UnitScript target;
    public UnitScript Target => target;
    #endregion

    protected virtual void Update()
    {
        FindTarget();
    }

    public void Move(Vector3 pos)
    {
        Vector3 dir = (pos - transform.position).normalized;
        dir.y = 0;
        transform.position += dir * currentSpeed * Time.deltaTime;
        unitAnimation.WalkAnimation(currentSpeed, unitData.moveSpeed);
    }


    /// <summary>
    /// 리스트에서 가장 가까운 타겟을 찾음
    /// </summary>
    private void FindTarget()
    {
        float targetDistance = 0;
        bool isCanBeTarget = false;

        List<UnitScript> enemies;
        if (!unitData.isHuman)
        {
            enemies = UnitManager.Instance.HumanList;
        }
        else
        {
            enemies = UnitManager.Instance.FishList;
        }
        foreach (UnitScript enemy in enemies)
        {
            if (target == null)
            {
                targetDistance = Vector3.Distance(enemy.transform.position, transform.position);
                if (targetDistance < unitData.sightRange)
                {
                    isCanBeTarget = CheckTarget(unitData, enemy);
                }
            }
            else
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) < targetDistance)
                {
                    isCanBeTarget = CheckTarget(unitData, enemy);
                }
            }

            if (isCanBeTarget)
                target = enemy;
        }
    }

    /// <summary>
    /// 타겟팅 가능이면 ture, 아니면 false.
    /// </summary>
    /// <param name="data">내 데이터</param>
    /// <param name="enemy">적 데이터</param>
    private bool CheckTarget(UnitDataSO data, UnitScript enemy)
    {
        if (!data.isSkyAtk && enemy.UnitData.isFly)
            return false;

        //추후 조건이 추가 될 수 있음

        return true;
    }


    public virtual void GetHit(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    public virtual void GetSlowness(float percent, float time)
    {
        StartCoroutine(SlownessCoroutine(percent, time));
    }

    private IEnumerator SlownessCoroutine(float percent, float time)
    {
        float slowness = currentSpeed * percent * 0.01f;
        currentSpeed -= slowness;
        yield return new WaitForSeconds(time);
        currentSpeed += slowness;
    }

    public virtual void Die()
    {
        unitAnimation.DeathAnimation();
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        StopAllCoroutines();
        currentHP = unitData.hp;
        currentSpeed = unitData.moveSpeed;
    }
}