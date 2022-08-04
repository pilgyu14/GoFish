using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{

    private List<CardObj> _cardList = new List<CardObj>();
    private List<DroppableUI> _slotList = new List<DroppableUI>();
    public List<CardObj> CardList => _cardList;


    [SerializeField]
    private CardObj _cardObj;
    [SerializeField]
    private CardDataSO _deckDataSO; // ���� �� (ó���� �������) 

    [SerializeField]
    private StageDataListSO _stageDataListSO;

    [SerializeField]
    private Transform _cardInventory; // ȭ�� �ϴ��� ī�� ����� 
    [SerializeField]
    private GameObject _summonImage; // ��ȯ�� ��ġ �����̹��� 


    private void Start()
    {
        SetSlots(); 
    }
    private void SetSlots()
    {
        int count = _cardInventory.childCount; 
        for (int i = 0;i < count;i++)
        {
            DroppableUI droppableUI = _cardInventory.GetChild(i).GetComponent<DroppableUI>();
            _slotList.Add(droppableUI);
        }
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
        foreach(var slot in _slotList)
        {
            Transform cardObj = slot.transform.Find("CardObj"); 
            if(cardObj != null)
            {
                CardData cardData = cardObj.GetComponent<CardObj>().CardData;
            }
        }
    }
    
    /// <summary>
    /// (��ư �Լ�) ���� �������� ���� 
    /// </summary>
    /// <param name="battleStageType"></param>
    private void OnCheckStage(BattleStageType battleStageType)
    {
        StageManager.Instance.CurrentStageData = _stageDataListSO._stageDataList.Find((x) => x._stageType == battleStageType);
    }

    public void SelectCard()
    {
        _summonImage.SetActive(true); 
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
