using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkRangeDecision : UnitDecision
{
    public override bool MakeADecision()
    {
        if (Vector3.Distance(unit.Target.transform.position, unit.transform.position) < unit.UnitData.atkRange)
        {
            return true;
        }
        return false;
    }
}
