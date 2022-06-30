using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Battle/DeckDataSO")]
public class DeckDataSO : ScriptableObject
{
    public List<CardData> cardDataList = new List<CardData>(); 
}
