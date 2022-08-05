using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CardComponent
{
    // ����� ���� 
    private List<CardObj> _cardList = new List<CardObj>();
    [SerializeField] // �ӽ� ����ȭ 
    private List<DroppableUI> _slotList = new List<DroppableUI>();

    private BattleManager _battleManager;
    private CardObj _selectedCard; // ���õ� ī�� 

    // ���� ���� 
    [SerializeField]
    private CardGivenComponent _cardGivenComponent;
    [SerializeField]
    private CardDataSO _deckDataSO; // ����    �� (ó���� �������) 
    [SerializeField]
    private Transform _cardInventory; // ȭ�� �ϴ��� ī�� ����� 
    [SerializeField]
    private GameObject _summonImage; // ��ȯ�� ��ġ �����̹��� 

    // ������Ƽ 
    public CardGivenComponent CardGivenComponent => _cardGivenComponent;
    public List<CardObj> CardList => _cardList;
    public GameObject SummonPoint => _summonImage;
    public CardObj SelectedCard
    {
        get => _selectedCard;
        set
        {
            _selectedCard = value;
        }
    }

    public void Initialize(BattleManager battleManager)
    {
        _battleManager = battleManager;
        SetSlots();
        _cardGivenComponent.Initialize();
        EventManager.Instance.StartListening(EventsType.SetDeckCard, SetDeckCard);
    }


    /// <summary>
    /// ���� ����Ʈ�� �߰� 
    /// </summary>
    private void SetSlots()
    {
        int count = _cardInventory.childCount;
        for (int i = 0; i < count; i++)
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
        foreach (var slot in _slotList)
        {
            Transform cardObj = slot.transform.Find("CardObj");
            if (cardObj != null)
            {
                cardObj.GetComponent<DraggableUI>().enabled = false; // �巡�� �ȵǵ��� ���� 
                CardData cardData = cardObj.GetComponent<CardObj>().CardData;
                _deckDataSO.cardDataList.Add(cardData);

                CardObj newCard = cardObj.GetComponent<CardObj>();
                _cardList.Add(newCard);
            }
        }
        _battleManager.IsBattle = true;
    }

    /// <summary>
    /// ī�� ���� 
    /// </summary>
    /// <param name="cardObj"></param>
    public void SelectCard(CardObj cardObj)
    {
        _summonImage.SetActive(true);
        _selectedCard = cardObj;
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
