using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField] protected UnitDataSO unitData;
    public UnitDataSO UnitData => unitData;

    [SerializeField] protected UnitAI unitAI;
    public UnitAI AI => unitAI;

    public void GetHit()
    {
        unitData.hp--;
        //�´� �ִϸ��̼�
    }

    public void Die()
    {
        //�״� �ִϸ��̼� �� ���� ����
    }
}
