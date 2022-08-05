using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanChaseState : UnitState
{
    protected override void Awake()
    {
        base.Awake();
        ai.dir = Random.insideUnitSphere;
        ai.dir.y = 0;
        ai.dir = ai.dir.normalized;
    }
    public override void ActionEnd()
    {

    }

    public override void ActionStart()
    {
    }

    public override void ActionUpdate()
    {
        unit.Move(ai.dir + unit.transform.position);
    }
}
