using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2State : UnitState
{
    public override void ActionEnd()
    {
        Debug.Log($"{ai.frame} :  End");
    }

    public override void ActionStart()
    {
        Debug.Log($"{ai.frame} :  Start");
    }

    public override void ActionUpdate()
    {
        Debug.Log($"{ai.frame} :  Update");
    }
}
