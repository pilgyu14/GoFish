using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitState : MonoBehaviour
{
    protected UnitAI ai;
    [SerializeField] List<UnitTransition> transitions;

    private void Awake()
    {
        ai = GetComponentInParent<UnitAI>(); 
    }

    public abstract void ActionStart();
    public abstract void ActionUpdate();
    public abstract void ActionEnd();


    public void CheckTransition()
    {
        if (transitions.Count <= 0) return;
        foreach (UnitTransition transition in transitions)
        {
            if (transition.CheckDecisions())
            {
                ai.ChangeState(transition.NextState);
            }
        }
    }
}
