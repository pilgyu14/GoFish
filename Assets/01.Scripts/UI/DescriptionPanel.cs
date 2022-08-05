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
        _costText.text = string.Format("�ʿ� �ڽ�Ʈ : " +cardData.cost.ToString());
        _hpText.text = string.Format("ü�� : " + cardData.hp.ToString());
        _atkText.text = string.Format("���ݷ� : " + cardData.damage.ToString());
        _asText.text = string.Format("���� �ӵ� : " + cardData.attackDelay.ToString());
        _speedText.text = string.Format("�̵� �ӵ� : " + cardData.moveSpeed.ToString());
        _attackRangeText.text = string.Format("���� ���� : " + cardData.attackRange.ToString());
        _descriptionText.text = cardData.description; 
    }
}
