using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class WarrningComponent : MonoBehaviour
{
    //�ν����� ����
    [SerializeField]
    private RectTransform _warrningTransform = null;
    [SerializeField]
    private TextMeshProUGUI _textMeshPro = null;
    //����
    private Tweener _tweener = null;

    public void Start()
    {
        Initialized();
    }
      

    /// <summary>
    /// �ʱ�ȭ
    /// </summary>
    public void Initialized()
    {
        _tweener = _warrningTransform.DOAnchorPosY(-2000, 1).SetDelay(1).SetAutoKill(false).
            OnComplete(() => _warrningTransform.gameObject.SetActive(false));
    }

    /// <summary>
    /// ��� �޽��� ���
    /// </summary>
    /// <param name="text"></param>
    public void SetWarrning(string text)
    {
        _warrningTransform.gameObject.SetActive(true);
        _textMeshPro.text = text;
        _tweener.Pause();
        _warrningTransform.anchoredPosition = new Vector2(0, 0);
        _tweener.Restart();
    }

}
