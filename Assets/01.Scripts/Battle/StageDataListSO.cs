using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

[Serializable]
public enum BattleStageType
{
    S1_1,
    S1_2,
    S1_3,
    S1_4,
    S1_5,
}

[CreateAssetMenu(menuName = "SO/Stage/StageDataListSO")]
public class StageDataListSO : ScriptableObject
{
    [Header("�������� ������")]
    public List<StageData> stageDataList = new List<StageData>();
}

[System.Serializable]
public class StageData
{
    public BattleStageType _stageType;
    public string _stageName;
    public float timeValue;
    
    [Header("�־��� ���ֵ�")]
    public List<CardNamingType> playerCardList = new List<CardNamingType>(); // �־��� ī��� 
}

