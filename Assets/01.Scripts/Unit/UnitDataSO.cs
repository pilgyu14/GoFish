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

    public float atk;
    public float atkRange;
    public float atkDelay;
    public float sightRange;
}
