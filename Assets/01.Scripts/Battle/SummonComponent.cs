using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[Serializable]
public class SummonComponent 
{
    [SerializeField]
    private UnitListSO _unitListSO;
    
    private CardObj _selectedCard; // ���õ�(��ȯ��) ī��
    private BattleManager _battleManger; 
    private CardComponent _cardComponent;
    private CostComponent _costComponent;
    [SerializeField]
    private bool _isSummonable; // ��ȯ�����Ѱ� 

    [Header("�� ��ȯ ���� ����")]
    [SerializeField]
    private UnitListSO _enemyListSO;
    [SerializeField]
    private Transform _enemySpawnPoint;

    public UnityEvent summonEvent;

    public bool IsSummonable
    {
        get => _isSummonable;
        set
        {
            _isSummonable = value;
        }
    }
    public void Initialize( CardComponent cardComponent, CostComponent costComponent)
    {
        _cardComponent = cardComponent;
        _costComponent = costComponent;
    }
    public void UpdateSomething()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetMouseButtonDown(0) && _cardComponent.SelectedCard != null && _isSummonable == true) // ���õ� ī�尡 �ְ� ��Ŭ���� 
        {
            if(_costComponent.Money < _cardComponent.SelectedCard.CardData.cost) // �� ������ 
            {
                // ���� �����մϴ� �г� 
                _costComponent.WarrningComponent.SetWarrning("���� �����մϴ�");
                return; 
            }
            if(scene.name == "Tutorial1")
            {
                summonEvent?.Invoke();
            }
            SummonUnit();
            _costComponent.MinusMoney(_cardComponent.SelectedCard.CardData.cost);
        }
    }

    /// <summary>
    /// �� ���� ��ȯ 
    /// </summary>
    public void SummonEnemy()
    {
        int count = _enemyListSO.unitList.Count; // �� ���� ���� 
        int randomUnitIdx = Random.Range(0, count);
        UnitScript newUnit = _enemyListSO.unitList[randomUnitIdx];
        UnitManager.Instance.SummonUnit(newUnit, _enemySpawnPoint.position, Vector3.zero);
        //SetPosAndRot(newUnit2.transform, _enemySpawnPoint.position);  // ��ġ ȸ�� ����
    }
    /// <summary>
    /// �Ʊ� ���� ��ȯ 
    /// </summary>
    private void SummonUnit()
    {
        CardNamingType selectedCardType = _cardComponent.SelectedCard.CardData.cardNamingType;
        UnitScript newUnit = _unitListSO.unitList.Find((x) => x.UnitData.cardNamingType == selectedCardType); // ������ ���� ã��  
        Vector3 summonPos = _cardComponent.SummonPoint.transform.position;
        summonPos += Vector3.up * 3; 
        UnitManager.Instance.SummonUnit(newUnit, summonPos, Vector3.zero); // ���� ����

    }

    /// <summary>
    /// ���� ������ ȸ�� ����
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="targetPos"></param>
    private void SetPosAndRot(Transform unit,Vector3 targetPos)
    {
        unit.position = targetPos;
        unit.rotation = Quaternion.identity; 
    }
}
