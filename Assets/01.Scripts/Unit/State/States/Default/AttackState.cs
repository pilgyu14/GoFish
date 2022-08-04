using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : UnitState
{
    public override void ActionEnd()
    {
        throw new System.NotImplementedException();
    }

    public override void ActionStart()
    {
        unit.UnitAttack.Attack(unit.Target);
    }

    public override void ActionUpdate()
    {
        throw new System.NotImplementedException();
    }
}
