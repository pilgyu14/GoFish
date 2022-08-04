using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAttackDecision : UnitDecision
{
    public override bool MakeADecision()
    {
        return ai.Unit.UnitAttack.IsCanAttack;
    }
}
