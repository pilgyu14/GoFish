using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class DroppableUI : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rectTrm;

    // �ν����� ���� ���� 
    [SerializeField]
    private Color _originColor; // �⺻ �� 
    [SerializeField]
    private Color _accentColor; // ���� �� 

    [SerializeField]
    private bool _isDroppedItem; // �������� ��ӵǾ� �ִ°�(������ �������� �ִ°�) 
    [SerializeField]
    private bool _isPlayerSlot; // �÷��̾� �����ΰ� (�ƴ϶�� �� ���ý� �־����� ����) 

    // ������Ƽ 
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
    /// ������ �������� ���� ��� _isDroppedItem -> true 
    /// </summary>
    private void CheckDroppedItme()
    {
        Transform cardObj = transform.Find("CardObj");
        if(cardObj != null) // ������ �������� ���� ��� 
        {
            _isDroppedItem = true;
            return; 
        }
        _isDroppedItem = false; 
    }
    /// <summary>
    /// ���콺 �����Ͱ� ������ �� 1ȸ ȣ��
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = _accentColor; 
    }

    /// <summary>
    /// ���콺 �����Ͱ� ������ �� 1ȸ ȣ�� 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = _originColor; 
    }
    /// <summary>
    /// �ٸ� ������Ʈ�� �ڽ� ������ �巡�װ� ������ �� 1ȸ ȣ�� 
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
