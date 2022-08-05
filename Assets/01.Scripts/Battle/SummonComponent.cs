using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random; 

[Serializable]
public class SummonComponent 
{
    [SerializeField]
    private UnitListSO _unitListSO;
    
    private CardObj _selectedCard; // ���õ�(��ȯ��) ī��
    private CardComponent _cardComponent;
    private CostComponent _costComponent;
    [SerializeField]
    private bool _isSummonable; // ��ȯ�����Ѱ� 

    [Header("�� ��ȯ ���� ����")]
    [SerializeField]
    private UnitListSO _enemyListSO;
    [SerializeField]
    private Transform _enemySpawnPoint;

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
        if(Input.GetMouseButtonDown(0) && _cardComponent.SelectedCard != null && _isSummonable == true) // ���õ� ī�尡 �ְ� ��Ŭ���� 
        {
            if(_costComponent.Money < _cardComponent.SelectedCard.CardData.cost) // �� ������ 
            {
                // ���� �����մϴ� �г� 
                _costComponent.WarrningComponent.SetWarrning("���� �����մϴ�");
                return; 
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
        UnitScript newUnit2 = PoolManager.Instance.Pop(newUnit) as UnitScript; // ���� ���� 
        newUnit2.transform.position = _enemySpawnPoint.position;
        //SetPosAndRot(newUnit2.transform, _enemySpawnPoint.position);  // ��ġ ȸ�� ����
    }
    /// <summary>
    /// �Ʊ� ���� ��ȯ 
    /// </summary>
    private void SummonUnit()
    {
        CardNamingType selectedCardType = _cardComponent.SelectedCard.CardData.cardNamingType;
        UnitScript newUnit = _unitListSO.unitList.Find((x) => x.UnitData.cardNamingType == selectedCardType); // ������ ���� ã��  
        newUnit = PoolManager.Instance.Pop(newUnit) as UnitScript; // ���� ���� 
        SetPosAndRot(newUnit.transform, _cardComponent.SummonPoint.transform.position);
        newUnit.transform.position += Vector3.up * 5; 
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
