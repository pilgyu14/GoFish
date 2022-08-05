using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Battle/DeckDataSO")]
public class CardDataSO : ScriptableObject
{
    public List<CardData> cardDataList = new List<CardData>(); 

    public void ClearDeck()
    {
        cardDataList.Clear(); 
    }
}
