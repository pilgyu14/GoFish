using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public SummonComponent SummonComponent => _summonComponent; 
    private void Start()
    {
        _cardComponent.Initialize(this,_costComponent);
        _summonComponent.Initialize(_cardComponent,_costComponent);
        _costComponent.Initialize(this); 

        StartCoroutine(SpawnEnemy());
        StartCoroutine(AddMoney()); 
    }
    private void Update()
    {
        if(_isBattle == false)
        {
            return; 
        }
        _summonComponent.UpdateSomething();
    }

    private IEnumerator AddMoney()
    {
        while (_isBattle == false)
        {
            yield return null;
        }

        float time = _costComponent.Time; 
        WaitForSeconds waitForSeconds = new WaitForSeconds(time);

        while (true)
        {
            if (_isBattle == false)
            {
                continue;
            }
            _costComponent.AddMoney(); 
            yield return waitForSeconds;
        }
    }
    private IEnumerator SpawnEnemy()
    {
        Scene scene = SceneManager.GetActiveScene();

        while (_isBattle == false)
        {
            yield return null;
        }
        
        float time = StageManager.Instance.CurrentStageData.enemySpawnTime;
        WaitForSeconds waitForSeconds = new WaitForSeconds(time);

        while(true)
        {
            if(scene.name == "Tutorial1")
            {
                break;
            }

            if(_isBattle == false)
            {
                continue; 
            }
            _summonComponent.SummonEnemy();
            yield return waitForSeconds; 
        }
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

    public void EnemyFunction()
    {
        _summonComponent.SummonEnemy();
    }
}
