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
    
    private CardObj _selectedCard; // 선택된(소환할) 카드
    private BattleManager _battleManger; 
    private CardComponent _cardComponent;
    private CostComponent _costComponent;
    [SerializeField]
    private bool _isSummonable; // 소환가능한가 

    [Header("적 소환 관련 변수")]
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
        if (Input.GetMouseButtonDown(0) && _cardComponent.SelectedCard != null && _isSummonable == true) // 선택된 카드가 있고 좌클릭시 
        {
            if(_costComponent.Money < _cardComponent.SelectedCard.CardData.cost) // 돈 부족시 
            {
                // 돈이 부족합니다 패널 
                _costComponent.WarrningComponent.SetWarrning("돈이 부족합니다");
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
    /// 적 유닛 소환 
    /// </summary>
    public void SummonEnemy()
    {
        int count = _enemyListSO.unitList.Count; // 적 유닛 종류 
        int randomUnitIdx = Random.Range(0, count);
        UnitScript newUnit = _enemyListSO.unitList[randomUnitIdx];
        UnitManager.Instance.SummonUnit(newUnit, _enemySpawnPoint.position, Vector3.zero);
        //SetPosAndRot(newUnit2.transform, _enemySpawnPoint.position);  // 위치 회전 설정
    }
    /// <summary>
    /// 아군 유닛 소환 
    /// </summary>
    private void SummonUnit()
    {
        CardNamingType selectedCardType = _cardComponent.SelectedCard.CardData.cardNamingType;
        UnitScript newUnit = _unitListSO.unitList.Find((x) => x.UnitData.cardNamingType == selectedCardType); // 선택한 유닛 찾기  
        Vector3 summonPos = _cardComponent.SummonPoint.transform.position;
        summonPos += Vector3.up * 3; 
        UnitManager.Instance.SummonUnit(newUnit, summonPos, Vector3.zero); // 유닛 생성

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
