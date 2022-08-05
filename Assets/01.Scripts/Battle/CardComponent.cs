using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CardComponent
{
    // 비공개 변수 
    private List<CardObj> _cardList = new List<CardObj>();
    [SerializeField] // 임시 직렬화 
    private List<DroppableUI> _slotList = new List<DroppableUI>();

    private BattleManager _battleManager;
    [SerializeField]
    private CardObj _selectedCard; // 선택된 카드 

    // 참조 변수 
    [SerializeField]
    private CardGivenComponent _cardGivenComponent;
    [SerializeField]
    private CardDataSO _deckDataSO; // 현재    덱 (처음엔 비어있음) 
    [SerializeField]
    private Transform _cardInventory; // 화면 하단의 카드 저장소 
    [SerializeField]
    private SummonPoint _summonImage; // 소환될 위치 강조이미지 
    [SerializeField]
    private DescriptionPanel _descriptionPanel;

    // 프로퍼티 
    public CardGivenComponent CardGivenComponent => _cardGivenComponent;
    public List<CardObj> CardList => _cardList;
    public SummonPoint SummonPoint => _summonImage;
    public CardObj SelectedCard
    {
        get => _selectedCard;
        set
        {
            _selectedCard = value;
        }
    }
    public DescriptionPanel DescriptionPanel => _descriptionPanel; 


    public void Initialize(BattleManager battleManager)
    {
        _battleManager = battleManager;
        SetSlots();
        _cardGivenComponent.Initialize();
        EventManager.Instance.StartListening(EventsType.SetDeckCard, SetDeckCard);
    }


    /// <summary>
    /// 슬롯 리스트에 추가 
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
    /// 덱에 카드 정보들을 넣는다 (시작버튼 클릭시 호출) 
    /// </summary>
    private void SetDeckCard()
    {
        foreach (var slot in _slotList)
        {
            Transform cardObj = slot.transform.Find("CardObj");
            if (cardObj != null)
            {
                cardObj.GetComponent<DraggableUI>().enabled = false; // 드래그 안되도록 설정 
                CardObj newCard = cardObj.GetComponent<CardObj>();
                newCard.enabled = true; 

                CardData cardData = newCard.CardData;
                _deckDataSO.cardDataList.Add(cardData);

                _cardList.Add(newCard);
            }
        }
        _battleManager.IsBattle = true;
    }

    /// <summary>
    /// 카드 선택 
    /// </summary>
    /// <param name="cardObj"></param>
    public void SelectCard(CardObj cardObj)
    {
        _summonImage.gameObject.SetActive(true);
        _selectedCard = cardObj;
    }
    /// <summary>
    /// 덱에 카드 추가 
    /// </summary>
    public void AddCard(CardObj cardObj)
    {
        _cardList.Add(cardObj);
    }
    /// <summary>
    /// 덱에 추가된 카드 해제 
    /// </summary>
    public void CancelCard(CardObj cardObj)
    {
        _cardList.Remove(cardObj);
    }
    // 카드덱 카드 장착 
    // 카드덱 카드 해제 
    // 카
}
