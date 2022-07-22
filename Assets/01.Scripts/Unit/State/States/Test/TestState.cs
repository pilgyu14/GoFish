using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState : UnitState
{
    public override void ActionEnd()
    {
        Debug.Log($"{ai.frame} : Test End!");
    }

    public override void ActionStart()
    {
        Debug.Log($"{ai.frame} : Test Start!");
    }

    public override void ActionUpdate()
    {
        Debug.Log($"{ai.frame} : Test Update!");
    }
}
