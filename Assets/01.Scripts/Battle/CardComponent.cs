using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    public List<CardObj> CardList => _cardList;

    private List<CardObj> _cardList = new List<CardObj>(); 
    
    [SerializeField]
    private CardObj _cardObj;
    [SerializeField]
    private CardDataSO _deckDataSO; // ���� �� (ó���� �������) 

    [SerializeField]
    private StageDataListSO _stageDataListSO;

    [SerializeField]
    private Transform _cardInventory; // ȭ�� �ϴ��� ī�� ����� 

    private void Start()
    {
        
    }
    public void SetCard()
    {
        _deckDataSO.ClearDeck(); 
    }

    /// <summary>
    /// ���� ī�� �������� �ִ´� (���۹�ư Ŭ���� ȣ��) 
    /// </summary>
    private void SetDeckCard()
    {
        int count = _cardInventory.childCount; // ���� ���� 
        for(int i =0; i < count; i++)
        {
            Transform slot = _cardInventory.GetChild(i);
            if(slot.childCount > 0) // ���Կ� ������ ī�尡 ������ 
            {
                CardData cardData = slot.GetChild(0).GetComponent<CardObj>().CardData;
            }
        }
        //int count = _cardDeckSO.cardDatas.Count;
        //for (int i = 0; i < count; i++)
        //{
        //    CardData cardData = _cardDeckSO.cardDatas[i];
        //    _deckData.Add_CardData(cardData);
        //}
    }
    
    /// <summary>
    /// (��ư �Լ�) ���� �������� ���� 
    /// </summary>
    /// <param name="battleStageType"></param>
    private void OnCheckStage(BattleStageType battleStageType)
    {
        StageManager.Instance.CurrentStageData = _stageDataListSO._stageDataList.Find((x) => x._stageType == battleStageType);
    }
    /// <summary>
    /// ���� ī�� �߰� 
    /// </summary>
    public void AddCard(CardObj cardObj)
    {
        _cardList.Add(cardObj); 
    }
    /// <summary>
    /// ���� �߰��� ī�� ���� 
    /// </summary>
    public void CancelCard(CardObj cardObj)
    {
        _cardList.Remove(cardObj); 
    }
    // ī�嵦 ī�� ���� 
    // ī�嵦 ī�� ���� 
    // ī
}