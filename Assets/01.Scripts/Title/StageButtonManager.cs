using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonManager : MonoBehaviour
{
    [SerializeField]
    private StageDataListSO _stageDataListSO; 
    public Button[] stageButtons;

    public bool[] isClear;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Stage2"))
        {
            PlayerPrefs.SetInt("Stage2", System.Convert.ToInt16(0));
            PlayerPrefs.SetInt("Stage3", System.Convert.ToInt16(0));
            PlayerPrefs.SetInt("Stage4", System.Convert.ToInt16(0));
            PlayerPrefs.SetInt("Stage5", System.Convert.ToInt16(0));
        }

        //스테이지 클리어시 넣어줘야함
        //PlayerPrefs.SetInt("Stage2", System.Convert.ToInt16(1);
        //PlayerPrefs.SetInt("Stage3", System.Convert.ToInt16(1));
        //PlayerPrefs.SetInt("Stage4", System.Convert.ToInt16(1));
        //PlayerPrefs.SetInt("Stage5", System.Convert.ToInt16(1));

        isClear[1] = System.Convert.ToBoolean(PlayerPrefs.GetInt("Stage2"))!;
        isClear[2] = System.Convert.ToBoolean(PlayerPrefs.GetInt("Stage3"))!;
        isClear[3] = System.Convert.ToBoolean(PlayerPrefs.GetInt("Stage4"))!;
        isClear[4] = System.Convert.ToBoolean(PlayerPrefs.GetInt("Stage5"))!;
    }

    void Start()
    {
        for(int i = 0; i < stageButtons.Length; i++)
        {
            if(isClear[i] == false)
            {
                stageButtons[i].interactable = false;
            }
        }
        EventManager.Instance.StartListening(EventsType.MoveStage, (x) => OnCheckStage((int)x));
    }

    /// <summary>
    /// (버튼 함수) 현재 스테이지 설정 
    /// </summary>
    /// <param name="battleStageType"></param>
    public void OnCheckStage(int battleStageType)
    {
        string name = System.Enum.GetName(typeof(BattleStageType), (BattleStageType)battleStageType);
        Debug.Log("스테이지가 설정 되었습니다" + name);
        BattleStageType stageType = (BattleStageType)battleStageType;
        StageManager.Instance.CurrentStageData = _stageDataListSO.stageDataList.Find((x) => x._stageType == stageType);
    }
}
