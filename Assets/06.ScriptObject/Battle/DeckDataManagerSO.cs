using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Deck/StandardDataSO")]
public class DeckDataManagerSO : ScriptableObject
{
    public List<CardData> cardDataList = new List<CardData>(); // 기준 카드 데이터(인스펙터 창에서 미리 설정해 둘것) 


}
