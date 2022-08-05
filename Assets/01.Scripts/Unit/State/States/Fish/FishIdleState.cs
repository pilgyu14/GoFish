using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishIdleState : UnitState
{
    public override void ActionStart()
    {

    }
    public override void ActionUpdate()
    {
        ai.Unit.Move(Vector3.zero);
    }
    public override void ActionEnd()
    {

    }

}
