using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{

}

public enum CardNamingType
{

}

public class CardData
{
    public CardType cardType; // 카드 타입
    public CardNamingType cardNamingType; // 각 카드 종류 

    public string name; // 이름
    public string description;  // 체력
    public int cost; // 코스트 
    public float damage; // 공격력
    public float attackDelay; // 공격 딜레이
    public float moveSpeed; // 이동 속도 
 
    public float attackRange;  // 공격 범위 
    public float traceDistance; // 추적 범위 
    public float traceAngle; // 추적 각도 

}