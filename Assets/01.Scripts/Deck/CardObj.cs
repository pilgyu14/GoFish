using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.EventSystems;

public class CardObj : PoolableObject, IPointerClickHandler
{
    [SerializeField]
    private Image _cardImage;
    [SerializeField]
    private TextMeshProUGUI _costText;
    [SerializeField]
    private TextMeshProUGUI _nameText;

    private BattleManager _battleManager;
    private bool _isBattleStarted; // ���� �����ߴ°�( ���� ��ư Ŭ���� true�� ���� )  
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

    /// <summary>
    /// ī�� ������ ���� 
    /// </summary>
    /// <param name="cardData"></param>
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

    /// <summary>
    /// Ŭ���� 1ȸ ���� 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        _battleManager.CardComponent.SelectCard(this); 
    }

    public override void Reset()
    {
    }
}
