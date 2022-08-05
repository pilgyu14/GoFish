using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public abstract class AbstractButton : MonoBehaviour
{
    [SerializeField]
    protected EventsType[] eventsTypes;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => Execute()); 
    }
    public abstract void Execute();
}
