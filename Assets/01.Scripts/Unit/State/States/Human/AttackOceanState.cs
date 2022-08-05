using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOceanState : UnitState
{
    public override void ActionEnd()
    {
    }

    public override void ActionStart()
    {
        unit.UnitAttack.Attack(null);
    }

    public override void ActionUpdate()
    {
    }
}
