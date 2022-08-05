using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class DescriptionPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameText;
    [SerializeField]
    private TextMeshProUGUI _costText;
    [SerializeField]
    private TextMeshProUGUI _hpText;
    [SerializeField]
    private TextMeshProUGUI _atkText;
    [SerializeField]
    private TextMeshProUGUI _asText;
    [SerializeField]
    private TextMeshProUGUI _speedText;
    [SerializeField]
    private TextMeshProUGUI _attackRangeText;
    [SerializeField]
    private TextMeshProUGUI _descriptionText;

    public void SetTexts(CardData cardData)
    {
        _nameText.text = cardData.name;
        _costText.text = string.Format("필요 코스트 : " +cardData.cost.ToString());
        _hpText.text = string.Format("체력 : " + cardData.hp.ToString());
        _atkText.text = string.Format("공격력 : " + cardData.damage.ToString());
        _asText.text = string.Format("공격 속도 : " + cardData.attackDelay.ToString());
        _speedText.text = string.Format("이동 속도 : " + cardData.moveSpeed.ToString());
        _attackRangeText.text = string.Format("공격 범위 : " + cardData.attackRange.ToString());
        _descriptionText.text = cardData.description; 
    }
}
