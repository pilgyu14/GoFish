using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : PoolableObject
{
    [SerializeField] private UnitDataSO unitData;
    public UnitDataSO UnitData => unitData;

    [SerializeField] private UnitAI unitAI;
    public UnitAI AI => unitAI;

    [SerializeField] private UnitAnimation unitAnimation;
    public UnitAnimation Animation => unitAnimation;

    [SerializeField] protected UnitAttack unitAttack;
    public UnitAttack UnitAttack => unitAttack;


    #region �������
    protected float currentHP = 0;
    protected float currentSpeed = 0;
    private UnitScript target;
    public UnitScript Target => target;
    public Vector3 destination;
    #endregion

    private void Awake()
    {
        currentHP = unitData.hp;
        currentSpeed = unitData.moveSpeed;
    }

    private void Update()
    {
        FindTarget();
    }

    public void Move(Vector3 pos)
    {
        Vector3 dir = (pos - transform.position).normalized;
        dir.y = 0;
        transform.position += dir * currentSpeed * Time.deltaTime;
        transform.forward = dir;
        unitAnimation.WalkAnimation(currentSpeed, unitData.moveSpeed);
    }


    /// <summary>
    /// ����Ʈ���� ���� ����� Ÿ���� ã��
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
    /// Ÿ���� �����̸� ture, �ƴϸ� false.
    /// </summary>
    /// <param name="data">�� ������</param>
    /// <param name="enemy">�� ������</param>
    private bool CheckTarget(UnitDataSO data, UnitScript enemy)
    {
        if (!data.isSkyAtk && enemy.UnitData.isFly)
            return false;

        //���� ������ �߰� �� �� ����

        return true;
    }


    public void GetHit(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    public void GetSlowness(float percent, float time)
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

    public void Die()
    {
        unitAnimation.DeathAnimation();
        UnitManager.Instance.DeleteInList(this);
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
        unitAI.Reset();
        currentHP = unitData.hp;
        currentSpeed = unitData.moveSpeed;
    }
}