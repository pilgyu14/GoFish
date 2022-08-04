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
    /// �巡�� ���۽� 1ȸ ȣ�� 
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
        if(transform.parent == _canvas) // �ٸ� ���Կ� ���� ���� 
         {
            Debug.Log("X"); 
            transform.SetParent(_prevParent);
        }
        else // �ٸ� ���Կ� ���� ����
        {
            _prevParent.GetComponent<DroppableUI>().IsDroppedItem = false; 
        }

        _rectTrm.anchoredPosition = Vector3.zero;
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
}
