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
    private CardDataSO _deckDataSO; // ���� �� (ó���� �������) 

    public void SetCard()
    {
        _deckDataSO.ClearDeck(); 
    }

    /// <summary>
    /// ���� ī�� �߰� 
    /// </summary>
    public void AddCard()
    {
        
    }
    /// <summary>
    /// ���� �߰��� ī�� ���� 
    /// </summary>
    public void CancelCard()
    {

    }
    // ī�嵦 ī�� ���� 
    // ī�嵦 ī�� ���� 
    // ī
}
