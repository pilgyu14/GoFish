using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{

}

public enum CardNamingType
{
    Carp, // �ؾ�
   Goldfish,  // �ݺؾ�
   Squid, // ��¡��
   Blowfish, // ����
   Flyingfish, // ��ġ 
   ElectricEll, // ���� ����� 
}

public class CardData
{
    public UnitType cardType; // ī�� Ÿ��
    public CardNamingType cardNamingType; // �� ī�� ���� 

    public string name; // �̸�
    public string description;  // ���� 
    public int cost; // �ڽ�Ʈ 
    public float damage; // ���ݷ�
    public float attackDelay; // ���� ������
    public float moveSpeed; // �̵� �ӵ� 
 
    public float attackRange;  // ���� ���� 
    public float traceDistance; // ���� ���� 
    public float traceAngle; // ���� ���� 

}