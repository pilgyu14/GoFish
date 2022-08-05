using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

[Serializable]
public class CardGivenComponent 
{
    [SerializeField]
    private CardObj _cardObj;
    [SerializeField]
    private Transform _cardInventory; 
    [SerializeField]
    private DeckDataManagerSO _deckDataManagerSO; // 기준 데이터 
    private List<DroppableUI> _slotList = new List<DroppableUI>();

    public void Initialize()
    {
        SetSlots();
        SetDeckData(); 
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

    [ContextMenu("덱세팅 테스트")] 
    /// <summary>
    /// 덱 생성 , 데이터 설정 ( 스테이지 선택후 넘어갈 때 호출 ) 
    /// </summary>
    public void SetDeckData()
    {
        int count = StageManager.Instance.CurrentStageData.playerCardList.Count;
        for (int i = 0; i < count; i++)
        {
            // 카드 생성 
            CardObj newCard = PoolManager.Instance.Pop(_cardObj) as CardObj;

            // 스테이지마다 주어지는 카드리스트 하나 가져오기 
            CardNamingType cardNamingType = StageManager.Instance.CurrentStageData.playerCardList[i];
            CardData cardData = _deckDataManagerSO.cardDataList.Find((x) => x.cardNamingType == cardNamingType);
            // 카드데이터 설정 
            newCard.SetCardData(cardData);

            // 슬롯 오브젝트 밑으로 
            newCard.transform.SetParent(_slotList[i].transform);
            newCard.transform.SetAsLastSibling();

            // 포지션 설정 
            newCard.GetComponent<RectTransform>().anchoredPosition = Vector3.zero; 

        }
    }
}
