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
    private bool _isPlayerCard; // 플레이어 슬롯에 등록된 카드인가  

    private void Awake()
    {
        _battleManager ??= FindObjectOfType<BattleManager>(); 
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = GameObject.Find("CardSelectCanvas").transform;
        _rectTrm = GetComponent<RectTransform>();
        _cardObj = GetComponent<CardObj>();

    }
    /// <summary>
    /// 드래그 시작시 1회 호출 
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
    /// 드래그 중인 동안 매 프레임 호출 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    /// <summary>
    /// 드래그가 끝날 때 1회 호출 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == _canvas) // 다른 슬롯에 장착 실패 
        {
            Debug.Log("X");
            transform.SetParent(_prevParent);
        }
        else // 다른 슬롯에 장착 성공
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
    /// 클릭시 1회 호출 
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
