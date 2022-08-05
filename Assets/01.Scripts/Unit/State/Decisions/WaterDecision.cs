using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDecision : UnitDecision
{
    LayerMask waterLayer;
    LayerMask groundLayer;

    protected override void Awake()
    {
        base.Awake();
        waterLayer = LayerMask.NameToLayer("Water");
        groundLayer = LayerMask.NameToLayer("Ground");
    }
    public override bool MakeADecision() //물가에 도착했을때 true
    {
        RaycastHit hit;
        if (Physics.Raycast(unit.transform.position + ai.dir * 2f + Vector3.up, Vector3.down, out hit, 10f, 1 << waterLayer | 1 << groundLayer))
        {
            if (hit.transform.CompareTag("Water"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
