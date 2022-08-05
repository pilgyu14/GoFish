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
    
    private CardObj _selectedCard; // 선택된(소환할) 카드
    private CardComponent _cardComponent;
    private BattleManager _battleManager;

    [Header("적 소환 관련 변수")]
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
        if(Input.GetMouseButtonDown(0) && _cardComponent.SelectedCard != null) // 선택된 카드가 있고 좌클릭시 
        {
            SummonUnit(); 
        }
    }

    /// <summary>
    /// 적 유닛 소환 
    /// </summary>
    public void SummonEnemy()
    {
        int count = _enemyListSO.unitList.Count; // 적 유닛 종류 
        int randomUnitIdx = Random.Range(0, count);
        UnitScript newUnit = _enemyListSO.unitList[randomUnitIdx];
        UnitScript newUnit2 = PoolManager.Instance.Pop(newUnit) as UnitScript; // 유닛 생성 
        newUnit2.transform.position = _enemySpawnPoint.position;
        //SetPosAndRot(newUnit2.transform, _enemySpawnPoint.position);  // 위치 회전 설정
    }
    /// <summary>
    /// 아군 유닛 소환 
    /// </summary>
    private void SummonUnit()
    {
        CardNamingType selectedCardType = _cardComponent.SelectedCard.CardData.cardNamingType;
        UnitScript newUnit = _unitListSO.unitList.Find((x) => x.UnitData.cardNamingType == selectedCardType); // 선택한 유닛 찾기  
        newUnit = PoolManager.Instance.Pop(newUnit) as UnitScript; // 유닛 생성 
        SetPosAndRot(newUnit.transform, _cardComponent.SummonPoint.transform.position);
        newUnit.transform.position += Vector3.up * 5; 
    }

    /// <summary>
    /// 유닛 포지션 회전 설정
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="targetPos"></param>
    private void SetPosAndRot(Transform unit,Vector3 targetPos)
    {
        unit.position = targetPos;
        unit.rotation = Quaternion.identity; 
    }
}
