using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitTransition : MonoBehaviour
{
    [SerializeField] List<UnitDecision> UnitDecisions;
    [SerializeField] private UnitState nextState;
    public UnitState NextState => nextState;
    [SerializeField] private bool condition; //�� ������ ���� CheckDecisions�� ��ȯ���� ���� ��� nextState���� �Ѿ����

    public bool CheckDecisions()
    {
        bool result = true;
        foreach(UnitDecision unitDecision in UnitDecisions)
        {
            if(condition != unitDecision.MakeADecision())
            {
                result = false;
            }
        }
        return result;
    }
}
