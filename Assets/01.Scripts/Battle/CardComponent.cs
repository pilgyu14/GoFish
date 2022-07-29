using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    public List<CardObj> CardList => _cardList;

    private List<CardObj> _cardList = new List<CardObj>(); 
    
    [SerializeField]
    private CardObj _cardObj;
    [SerializeField]
    private CardDataSO _deckDataSO; // 현재 덱 (처음엔 비어있음) 

    public void SetCard()
    {
        _deckDataSO.ClearDeck(); 
    }

    /// <summary>
    /// 덱에 카드 추가 
    /// </summary>
    public void AddCard()
    {
        
    }
    /// <summary>
    /// 덱에 추가된 카드 해제 
    /// </summary>
    public void CancelCard()
    {

    }
    // 카드덱 카드 장착 
    // 카드덱 카드 해제 
    // 카
}
