using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private Transform _canvas;
    private Transform _prevParent;
    private RectTransform _rectTrm;
    private BattleManager _battleManager;

    private CardObj _cardObj;
    private bool _isPlayerCard; // �÷��̾� ���Կ� ��ϵ� ī���ΰ�  

    private void Awake()
    {
        _battleManager ??= FindObjectOfType<BattleManager>(); 
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = GameObject.Find("CardSelectCanvas").transform;
        _rectTrm = GetComponent<RectTransform>();
        _cardObj = GetComponent<CardObj>();

    }
    /// <summary>
    /// �巡�� ���۽� 1ȸ ȣ�� 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        _prevParent = transform.parent;

        Debug.Log(transform.root);
        transform.SetParent(_canvas);
        transform.SetAsLastSibling();

        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// �巡�� ���� ���� �� ������ ȣ�� 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    /// <summary>
    /// �巡�װ� ���� �� 1ȸ ȣ�� 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == _canvas) // �ٸ� ���Կ� ���� ���� 
        {
            Debug.Log("X");
            transform.SetParent(_prevParent);
        }
        else // �ٸ� ���Կ� ���� ����
        {
            _prevParent.GetComponent<DroppableUI>().IsDroppedItem = false;
            if (transform.parent.GetComponent<DroppableUI>().IsPlayerSlot == true)
            {
                _isPlayerCard = true;
            }
        }

        _rectTrm.anchoredPosition = Vector3.zero;
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// Ŭ���� 1ȸ ȣ�� 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //if(_isPlayerCard == true)
        //{
        //    return; 
        //}
        _battleManager.CardComponent.DescriptionPanel.SetTexts(_cardObj.CardData); 
    }
}
