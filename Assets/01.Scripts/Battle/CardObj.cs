using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class CardObj : MonoBehaviour
{
    [SerializeField]
    private Image _cardImage;
    [SerializeField]
    private TextMeshProUGUI _costText;
    [SerializeField]
    private TextMeshProUGUI _nameText; 

    public void SetCardData(CardData cardData)
    {
        _cardImage.sprite = SkinData.GetSkin(cardData.skinData._skinType);
        _costText.text = cardData.cost.ToString();
        _nameText.text = cardData.name; 
    }
}
