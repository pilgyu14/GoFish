using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour
{
    protected UnitScript unit;
    protected UnitDataSO Data => unit.UnitData;
    protected UnitAnimation Animation => unit.Animation;
    protected bool isCanAttack;

    protected virtual void Awake()
    {
        unit = GetComponent<UnitScript>();
    }

    public abstract void Attack(UnitScript target);
}
