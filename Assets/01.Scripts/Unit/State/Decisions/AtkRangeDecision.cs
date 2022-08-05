using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkRangeDecision : UnitDecision
{
    public override bool MakeADecision()
    {
        if (unit.Target == null) return false;
        if (Vector3.Distance(unit.Target.transform.position, unit.transform.position) < unit.UnitData.atkRange)
        {
            return true;
        }
        else
            return false;
    }
}
