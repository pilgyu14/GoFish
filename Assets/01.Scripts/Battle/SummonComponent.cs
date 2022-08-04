using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonComponent 
{
    [SerializeField]
    private Transform summonPoint; // 소환 위치

    private CardObj _selectedCard; // 선택된(소환할) 카드
    
    /// <summary>
    /// 유닛 소환 
    /// </summary>
    public void SummonUnit()
    {

    }
}
