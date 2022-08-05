using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("�ڽ�Ʈ"), SerializeField]
    private CostComponent _costComponent;
    [Header("ī��"), SerializeField]
    private CardComponent _cardComponent;
    [Header("��ȯ"), SerializeField]
    private SummonComponent _summonComponent;

    [SerializeField]
    private StageDataListSO _stageDataListSO;

    [SerializeField] // �ӽ� ����ȭ 
    private bool _isBattle; // ���� �������ΰ� 
    
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
    /// (��ư �Լ�) ���� �������� ���� 
    /// </summary>
    /// <param name="battleStageType"></param>
    public void OnCheckStage(int battleStageType)
    {
        string name = System.Enum.GetName(typeof(BattleStageType), (BattleStageType)battleStageType); 
        Debug.Log("���������� ���� �Ǿ����ϴ�" + name); 
        BattleStageType stageType = (BattleStageType)battleStageType; 
        StageManager.Instance.CurrentStageData = _stageDataListSO.stageDataList.Find((x) => x._stageType == stageType);
    }

    [ContextMenu("�� �ҷ����� �׽�Ʈ")]
    /// <summary>
    /// �� �ҷ����� �� �׽�Ʈ�� �Լ� (���� ����) 
    /// </summary>
    public void SetDeckTest()
    {
        _cardComponent.CardGivenComponent.SetDeckData(); 
    }
}
