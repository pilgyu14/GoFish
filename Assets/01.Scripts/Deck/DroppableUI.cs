using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class DroppableUI : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rectTrm;

    // 인스펙터 참조 변수 
    [SerializeField]
    private Color _originColor; // 기본 색 
    [SerializeField]
    private Color _accentColor; // 강조 색 

    [SerializeField]
    private bool _isDroppedItem; // 아이템이 드롭되어 있는가(장착된 아이템이 있는가) 
    [SerializeField]
    private bool _isPlayerSlot; // 플레이어 슬롯인가 (아니라면 덱 선택시 주어지는 슬롯) 

    // 프로퍼티 
    public bool IsDroppedItem
    {
        get => _isDroppedItem;
        set
        {
            _isDroppedItem = value;
        }
    }

    public bool IsPlayerSlot
    {
        get => _isPlayerSlot;
        set
        {
            _isPlayerSlot = value;
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        rectTrm = GetComponent<RectTransform>(); 
    }
    private void Start()
    {
        image.color = _originColor;
        CheckDroppedItme(); 
    }

    /// <summary>
    /// 장착된 아이템이 있을 경우 _isDroppedItem -> true 
    /// </summary>
    private void CheckDroppedItme()
    {
        Transform cardObj = transform.Find("CardObj");
        if(cardObj != null) // 장착된 아이템이 있을 경우 
        {
            _isDroppedItem = true;
            return; 
        }
        _isDroppedItem = false; 
    }
    /// <summary>
    /// 마우스 포인터가 들어왔을 때 1회 호출
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = _accentColor; 
    }

    /// <summary>
    /// 마우스 포인터가 나갔을 때 1회 호출 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = _originColor; 
    }
    /// <summary>
    /// 다른 오브젝트가 자신 위에서 드래그가 끝났을 때 1회 호출 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerPress.name);
        if(_isDroppedItem == true)
        {
            return; 
        }

        if(eventData.pointerDrag != null)
        {
            Debug.Log("O");
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTrm.anchoredPosition;
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.SetAsLastSibling(); 
            _isDroppedItem = true; 
        }
    }

}
