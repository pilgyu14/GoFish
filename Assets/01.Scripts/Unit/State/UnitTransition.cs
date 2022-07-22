using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitTransition : MonoBehaviour
{
    [SerializeField] List<UnitDecision> UnitDecisions;
    [SerializeField] private UnitState nextState;
    public UnitState NextState => nextState;
    [SerializeField] private bool condition; //이 변수의 값과 CheckDecisions의 반환값이 같을 경우 nextState으로 넘어갈거임

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
