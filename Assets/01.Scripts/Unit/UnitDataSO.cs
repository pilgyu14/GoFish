using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Unit/Data")]
public class UnitDataSO : ScriptableObject
{
    [Header ("Ư��")]
    public bool isHuman;
    public bool isFly;
    public bool isSkyAtk;
    public bool isGroundAtk;
    
    [Header("����")]
    public readonly float moveSpeed;
    public readonly float hp;
    public readonly float cost;

    [Header("���ݰ���")]
    public readonly float atkDamage;
    public readonly float atkRange;
    public readonly float beforeDelay;
    public readonly float afterDelay;
    public float atkSpeed => 1 / (beforeDelay + afterDelay);
    public readonly float sightRange;
}
