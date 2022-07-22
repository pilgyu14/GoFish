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
        //맞는 애니메이션
    }

    public void Die()
    {
        //죽는 애니메이션 및 동작 정지
    }
}
