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
    private DeckDataManagerSO _deckDataManagerSO; // ���� ������ 
    private List<DroppableUI> _slotList = new List<DroppableUI>();

    public void Initialize()
    {
        SetSlots();
        SetDeckData(); 
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

    [ContextMenu("������ �׽�Ʈ")] 
    /// <summary>
    /// �� ���� , ������ ���� ( �������� ������ �Ѿ �� ȣ�� ) 
    /// </summary>
    public void SetDeckData()
    {
        int count = StageManager.Instance.CurrentStageData.playerCardList.Count;
        for (int i = 0; i < count; i++)
        {
            // ī�� ���� 
            CardObj newCard = PoolManager.Instance.Pop(_cardObj) as CardObj;

            // ������������ �־����� ī�帮��Ʈ �ϳ� �������� 
            CardNamingType cardNamingType = StageManager.Instance.CurrentStageData.playerCardList[i];
            CardData cardData = _deckDataManagerSO.cardDataList.Find((x) => x.cardNamingType == cardNamingType);
            // ī�嵥���� ���� 
            newCard.SetCardData(cardData);

            // ���� ������Ʈ ������ 
            newCard.transform.SetParent(_slotList[i].transform);
            newCard.transform.SetAsLastSibling();

            // ������ ���� 
            newCard.GetComponent<RectTransform>().anchoredPosition = Vector3.zero; 

        }
    }
}
