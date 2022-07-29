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
    protected UnitScript target;
    #endregion



    protected virtual void Update()
    {
        FindTarget(unitData);
    }

    protected void Move()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        dir.y = 0;
        transform.position += dir * unitData.moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// 리스트에서 가장 가까운 타겟을 찾음
    /// </summary>
    protected void FindTarget(UnitDataSO data)
    {
        if (target != null)
        {
            if (CheckDistance())
            {
                unitAttack.Attack(target);
            }
            else
            {
                Move();
            }
            return;
        }

        float targetDistance = 0;
        bool isCanBeTarget = false;

        List<UnitScript> enemies;
        if (!data.isHuman)
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
                    isCanBeTarget = CheckTarget(data, enemy);
                }
            }
            else
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) < targetDistance)
                {
                    isCanBeTarget = CheckTarget(data, enemy);
                }
            }

            if (isCanBeTarget)
                target = enemy;
        }
    }

    /// <summary>
    /// 공격 사거리 이내로 타겟이 들어왔다면 true를 반환
    /// </summary>
    protected bool CheckDistance()
    {
        if (target == null) return false;

        if (Vector3.Distance(target.transform.position, transform.position) < unitData.atkRange)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 타겟팅 가능이면 ture, 아니면 false.
    /// </summary>
    /// <param name="data">내 데이터</param>
    /// <param name="enemy">적 데이터</param>
    protected bool CheckTarget(UnitDataSO data, UnitScript enemy)
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

    public virtual void Die()
    {
        unitAnimation.DeathAnimation();
        StartCoroutine(DeathCoroutine());
    }

    public IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        currentHP = unitData.hp;
    }
}