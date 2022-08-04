using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<StageData> _stageDataList = new List<StageData>();
}

[System.Serializable]
public class StageData
{
    public BattleStageType _stageType;
    public string _stageName;
    public float timeValue;

    public List<CardNamingType> _playerCardList = new List<CardNamingType>(); // 주어질 카드들 
}

