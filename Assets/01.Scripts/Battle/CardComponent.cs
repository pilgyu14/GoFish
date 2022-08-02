using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    private CardData _cardData;

    public List<CardObj> CardList => _cardList;

    private List<CardObj> _cardList = new List<CardObj>(); 
    
    [SerializeField]
    private CardObj _cardObj;
    [SerializeField]
    private DeckDataSO _deckDataSO; 

    public void SetCard()
    {
                           
    }

}
