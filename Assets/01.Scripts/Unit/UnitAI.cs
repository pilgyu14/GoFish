using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    private UnitScript unit = null;
    public UnitScript Unit => unit;
    [SerializeField] private UnitState currentState = null;
    private UnitState startState = null;
    private bool isUpdate = false; //true�϶� ActionUpdate()�� CheckTransition()�� ������

    public Vector3 dir; //�ӽ÷� ��� ���� ���� ����

    private void Awake()
    {
        unit = transform.GetComponentInParent<UnitScript>();
        startState = currentState;
    }

    private void Start()
    {
        currentState.ActionStart();
        isUpdate = true;
    }

    private void Update()
    {
        if(isUpdate)
        {
            currentState.ActionUpdate();
            currentState.CheckTransition();
        }
    }

    public void ChangeState(UnitState state)
    {
        isUpdate = false;
        StartCoroutine(NextFrame(() => {
            currentState.ActionEnd();
            currentState = state;
            StartCoroutine(NextFrame(() =>
            {
                currentState.ActionStart();
                isUpdate = true;
            }));
        }));
    }

    private IEnumerator NextFrame(Action action)
    {
        yield return null;
        action?.Invoke();
    }

    public void Reset()
    {
        currentState = startState;
    }
}
