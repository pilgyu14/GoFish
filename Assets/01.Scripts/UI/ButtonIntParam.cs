    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIntParam : AbstractButton
{
    [SerializeField]
    private int[] intParams; 
    public override void Execute()
    {
        int count = eventsTypes.Length; 
        for(int i =0; i < count; i++)
        {
            EventManager.Instance.TriggerEvent(eventsTypes[i], intParams[i]);
        }
    }
}
