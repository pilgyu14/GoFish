using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public enum UnitType
{

}

public enum CardNamingType
{
    None, // 없음

   Carp, // 붕어
   Goldfish,  // 금붕어
   Squid, // 오징어
   Blowfish, // 복어
   Flyingfish, // 날치 
   ElectricEll, // 전기 뱀장어 
}

// UI로 보여줄 카드 정보,
// 소환시 UnitType으로 구분해서 소환 
[Serializable]
public class CardData
{
    public UnitType unitType; // 유닛 타입
    public CardNamingType cardNamingType; // 각 카드 종류 

    public SkinData skinData;
    public Sprite sprite; 

    public string name; // 이름
    public string description;  // 설명 
    public int cost; // 코스트 
    public float hp; // 체력 
    public float damage; // 공격력
    public float attackDelay; // 공격 딜레이
    public float moveSpeed; // 이동 속도 
 
    public float attackRange;  // 공격 범위 
    public float traceDistance; // 추적 범위 
    public float traceAngle; // 추적 각도 

}