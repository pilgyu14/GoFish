using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.EventSystems;

public class CardObj : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Image _cardImage;
    [SerializeField]
    private TextMeshProUGUI _costText;
    [SerializeField]
    private TextMeshProUGUI _nameText;

    private BattleManager _battleManager;
    private bool _isBattleStarted; // 전투 시작했는가( 시작 버튼 클릭시 true로 변경 )  
    private CardData _cardData;

    public CardData CardData => _cardData; 
    public bool IsBattleStarted
    {
        get => _isBattleStarted; 
        set
        {
            _isBattleStarted = value; 
        }
    }

    public void SetCardData(CardData cardData)
    {
        _cardData = cardData; 
        _battleManager ??= FindObjectOfType<BattleManager>(); 

        _cardImage.sprite = SkinData.GetSkin(cardData.skinData._skinType);
        _costText.text = cardData.cost.ToString();
        _nameText.text = cardData.name; 
    }

    public void AddCard()
    {
        _battleManager.CardComponent.AddCard(this);
    }
    public void CancelCard()
    {
        _battleManager.CardComponent.CancelCard(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
