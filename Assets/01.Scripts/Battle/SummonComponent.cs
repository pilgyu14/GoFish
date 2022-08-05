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
    private BattleManager _battleManager;

    [Header("�� ��ȯ ���� ����")]
    [SerializeField]
    private UnitListSO _enemyListSO;
    [SerializeField]
    private Transform _enemySpawnPoint; 

    public void Initialize( CardComponent cardComponent)
    {
        _cardComponent = cardComponent; 
    }
    public void UpdateSomething()
    {
        if(Input.GetMouseButtonDown(0) && _cardComponent.SelectedCard != null) // ���õ� ī�尡 �ְ� ��Ŭ���� 
        {
            SummonUnit(); 
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
