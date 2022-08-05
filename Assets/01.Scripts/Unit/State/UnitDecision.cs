using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class UnitDecision : MonoBehaviour
{
    protected UnitState state;
    public UnitAI ai => state.AI;
    public UnitScript unit => ai.Unit;

    protected virtual void Awake()
    {
        state = GetComponentInParent<UnitState>();
    }
    public abstract bool MakeADecision();
}
