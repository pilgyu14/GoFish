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
    public CardType cardType; // ī�� Ÿ��
    public CardNamingType cardNamingType; // �� ī�� ���� 

    public string name; // �̸�
    public string description;  // ü��
    public int cost; // �ڽ�Ʈ 
    public float damage; // ���ݷ�
    public float attackDelay; // ���� ������
    public float moveSpeed; // �̵� �ӵ� 
 
    public float attackRange;  // ���� ���� 
    public float traceDistance; // ���� ���� 
    public float traceAngle; // ���� ���� 

}