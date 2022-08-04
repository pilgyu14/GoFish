using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoSingleton<StageManager>
{
    private StageData _currentStageData;
    public StageData CurrentStageData
    {
        get => _currentStageData;
        set
        {
            _currentStageData = value;
        }
    }
    public List<CardData> cardDataList;


}
