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
    [Header("스테이지 데이터")]
    public List<StageData> stageDataList = new List<StageData>();
}

[System.Serializable]
public class StageData
{
    public BattleStageType _stageType;
    public string _stageName;
    [Header("적 소환 주기")]
    public float enemySpawnTime; 
    
    [Header("주어질 유닛들")]
    public List<CardNamingType> playerCardList = new List<CardNamingType>(); // 주어질 유닛들  
    [Header("나올 적 유닛들")]
    public List<CardNamingType> enemyUnitList = new List<CardNamingType>(); // 나올 적 유닛들  
}

