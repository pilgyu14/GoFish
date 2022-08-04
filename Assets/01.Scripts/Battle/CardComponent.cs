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
    private CardDataSO _deckDataSO; // 현재 덱 (처음엔 비어있음) 

    [SerializeField]
    private StageDataListSO _stageDataListSO;

    [SerializeField]
    private Transform _cardInventory; // 화면 하단의 카드 저장소 

    private List<DroppableUI> _slotList = new List<DroppableUI>(); 
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
    /// 덱에 카드 정보들을 넣는다 (시작버튼 클릭시 호출) 
    /// </summary>
    private void SetDeckCard()
    {
        foreach(var slot in _slotList)
        {
            CardData cardData = slot.transform.Find("CardObj").GetComponent<CardObj>().CardData; 
        }
        int count = _cardInventory.childCount; // 슬롯 개수 
        for(int i =0; i < count; i++)
        {
            Transform slot = _cardInventory.GetChild(i);
            if(slot.childCount > 0) // 슬롯에 장착된 카드가 있으면 
            {
                CardData cardData = slot.Find("CardObj").GetComponent<CardObj>().CardData;
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
    /// (버튼 함수) 현재 스테이지 설정 
    /// </summary>
    /// <param name="battleStageType"></param>
    private void OnCheckStage(BattleStageType battleStageType)
    {
        StageManager.Instance.CurrentStageData = _stageDataListSO._stageDataList.Find((x) => x._stageType == battleStageType);
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
