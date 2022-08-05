using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public enum UnitType
{

}

public enum CardNamingType
{
    None, // ����

   Carp, // �ؾ�
   Goldfish,  // �ݺؾ�
   Squid, // ��¡��
   Blowfish, // ����
   Flyingfish, // ��ġ 
   ElectricEll, // ���� ����� 
}

// UI�� ������ ī�� ����,
// ��ȯ�� UnitType���� �����ؼ� ��ȯ 
[Serializable]
public class CardData
{
    public UnitType unitType; // ���� Ÿ��
    public CardNamingType cardNamingType; // �� ī�� ���� 

    public SkinData skinData;
    public Sprite sprite; 

    public string name; // �̸�
    public string description;  // ���� 
    public int cost; // �ڽ�Ʈ 
    public float hp; // ü�� 
    public float damage; // ���ݷ�
    public float attackDelay; // ���� ������
    public float moveSpeed; // �̵� �ӵ� 
 
    public float attackRange;  // ���� ���� 
    public float traceDistance; // ���� ���� 
    public float traceAngle; // ���� ���� 

}