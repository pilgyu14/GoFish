using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private RectTransform _canvas;
    private Transform _prevParent;
    private RectTransform _rectTrm;

    private CardObj _cardObj; 
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = transform.root.GetComponent<RectTransform>();
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
        if(transform.parent == _canvas) // 다른 슬롯에 장착 실패 
         {
            Debug.Log("X"); 
            transform.SetParent(_prevParent);
        }
        else // 다른 슬롯에 장착 성공
        {
            _prevParent.GetComponent<DroppableUI>().IsDroppedItem = false; 
        }

        _rectTrm.anchoredPosition = Vector3.zero;
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
}
