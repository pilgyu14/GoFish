using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{

}

public enum CardNamingType
{
    Carp, // 붕어
   Goldfish,  // 금붕어
   Squid, // 오징어
   Blowfish, // 복어
   Flyingfish, // 날치 
   ElectricEll, // 전기 뱀장어 
}

public class CardData
{
    public UnitType cardType; // 카드 타입
    public CardNamingType cardNamingType; // 각 카드 종류 

    public string name; // 이름
    public string description;  // 설명 
    public int cost; // 코스트 
    public float damage; // 공격력
    public float attackDelay; // 공격 딜레이
    public float moveSpeed; // 이동 속도 
 
    public float attackRange;  // 공격 범위 
    public float traceDistance; // 추적 범위 
    public float traceAngle; // 추적 각도 

}