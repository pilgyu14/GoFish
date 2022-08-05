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
    public float moveSpeed;
    public float hp;
    public float cost;

    [Header("���ݰ���")]
    public float atkDamage;
    public float atkRange;
    public float beforeDelay;
    public float afterDelay;
    public float atkSpeed => 1 / (beforeDelay + afterDelay);
    public float sightRange;
}
