using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

[Serializable]
public class SummonComponent 
{
    [SerializeField]
    private UnitListSO _unitListSO; 
    
    private CardObj _selectedCard; // ���õ�(��ȯ��) ī��
    private CardComponent _cardComponent;
    private BattleManager _battleManager; 
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
    /// ���� ��ȯ 
    /// </summary>
    private void SummonUnit()
    {
        CardNamingType selectedCardType = _cardComponent.SelectedCard.CardData.cardNamingType;
        UnitScript newUnit = _unitListSO.unitList.Find((x) => x.UnitData.cardNamingType == selectedCardType); // ���� ���� 
        newUnit.transform.position = _cardComponent.SummonPoint.transform.position; // ���콺 ��ġ�� ������ ����  
    }
}
