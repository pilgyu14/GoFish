using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour
{
    protected UnitScript unit;
    public UnitDataSO unitData => unit.UnitData;
    protected UnitScript target;
    protected float targetDistance;
    protected bool isCanBeTarget;
    protected bool isDelay;
    public bool IsDelay => isDelay;

    protected virtual void Awake()
    {
        unit = GetComponent<UnitScript>();
    }

    protected virtual void Update()
    {
        FindTarget(unit.UnitData);
    }

    protected void FindTarget(UnitDataSO data)
    {
        if (target != null) return;

        List<UnitScript> enemies;
        if(!data.isHuman)
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
                if(Vector3.Distance(enemy.transform.position, transform.position) < targetDistance)
                {
                    isCanBeTarget = CheckTarget(data, enemy);
                }
            }

            if (isCanBeTarget)
                target = enemy;
        }
    }

    protected bool CheckTarget(UnitDataSO data, UnitScript enemy)
    {
        if (!data.isSkyAtk && enemy.UnitData.isFly)
            return false;

        //추후 조건이 추가 될 수 있음

        return true;
    }

    protected IEnumerator WaitDelay()
    {
        isDelay = true;
        yield return new WaitForSeconds(unitData.atkDelay);
        isDelay = false;
    }

    protected abstract void Attack();
}
