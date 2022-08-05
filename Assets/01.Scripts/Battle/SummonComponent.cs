using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

[Serializable]
public class SummonComponent 
{
    [SerializeField]
    private UnitListSO _unitListSO; 
    
    private CardObj _selectedCard; // 선택된(소환할) 카드
    private CardComponent _cardComponent;
    private BattleManager _battleManager; 
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
    /// 유닛 소환 
    /// </summary>
    private void SummonUnit()
    {
        CardNamingType selectedCardType = _cardComponent.SelectedCard.CardData.cardNamingType;
        UnitScript newUnit = _unitListSO.unitList.Find((x) => x.UnitData.cardNamingType == selectedCardType); // 유닛 생성 
        newUnit.transform.position = _cardComponent.SummonPoint.transform.position; // 마우스 위치로 포지션 설정  
    }
}
