using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Unit/Data")]
public class UnitDataSO : ScriptableObject
{
    [Header ("특성")]
    public bool isHuman;
    public bool isFly;
    public bool isSkyAtk;
    public bool isGroundAtk;
    
    [Header("스탯")]
    public readonly float moveSpeed;
    public readonly float hp;
    public readonly float cost;

    [Header("공격관련")]
    public float atkDamage;
    public float atkRange;
    public float beforeDelay;
    public float afterDelay;
    public float atkSpeed => 1 / (beforeDelay + afterDelay);
    public float sightRange;
}
