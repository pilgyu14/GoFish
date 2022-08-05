using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("코스트"), SerializeField]
    private CostComponent _costComponent;
    [Header("카드"), SerializeField]
    private CardComponent _cardComponent;
    [Header("소환"), SerializeField]
    private SummonComponent _summonComponent;

    [SerializeField]
    private StageDataListSO _stageDataListSO;

    [SerializeField] // 임시 직렬화 
    private bool _isBattle; // 현재 전투중인가 
    
    public bool IsBattle
    {
        get => _isBattle;
        set
        {
            _isBattle = value; 
        }
    }
    public CardComponent CardComponent => _cardComponent; 

    private void Start()
    {
        _cardComponent.Initialize(this);
        _summonComponent.Initialize(_cardComponent);
    }
    private void Update()
    {
        if(_isBattle == false)
        {
            return; 
        }
        _summonComponent.UpdateSomething();
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

    [ContextMenu("덱 불러오기 테스트")]
    /// <summary>
    /// 덱 불러오는 거 테스트용 함수 (지울 예정) 
    /// </summary>
    public void SetDeckTest()
    {
        _cardComponent.CardGivenComponent.SetDeckData(); 
    }
}
