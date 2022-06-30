using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public enum ViewType
{
    Topdown, 
    Moving, 
}

public class CameraController : MonoBehaviour
{
    public GameObject player; // 기준 오브젝트 
    public float xmove = 0;  // X축 누적 이동량
    public float ymove = 0;  // Y축 누적 이동량
    public float zoomValue; 
    public float distance = 3;

    public float SmoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;

    private Camera _mainCam;
    public Camera MainCam => _mainCam;

    private Vector3 _originPos,_originRot; 
    [SerializeField]
    private ViewType _curViewType; 

    [SerializeField]
    private float wheelspeed = 10.0f;
    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private float _minZoom = 5f;
    [SerializeField]
    private float _maxZoom = 50f;

    float x, y;

    private void Awake()
    {
        _parentTrans = transform.parent; 
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
    }
    private void Start()
    {
        targetPos = transform.position; 
        _curViewType = ViewType.Topdown;
        _originPos = new Vector3(0, 20, 0);
        _originRot = new Vector3(90, 0, 0); 
    }   
    void Update()
    {
        Cam(); 

    }
    [SerializeField]
    private float timeScale; 
    private void Cam()
    {
        ZoomInOut();
        RotateCam(); 
        if (_curViewType == ViewType.Topdown)
        {
     //       FixedCamera();
            return;
        }
        //MoveCam();
    }

    [SerializeField]
    private Transform _parentTrans; 
    [SerializeField]
    private float _camRotValue = 90; // 카메라 회전량 
    /// <summary>
    ///  카메라 회전 
    /// </summary>
    private void RotateCam()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _parentTrans.DOComplete();
            _parentTrans.DORotate(_parentTrans.eulerAngles + (Vector3.up * _camRotValue), 0.5f); 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _parentTrans.DOComplete();
            _parentTrans.DORotate(_parentTrans.eulerAngles + (Vector3.down * _camRotValue), 0.5f);
        }
    }

    [SerializeField]
    private int xDragDir = 1;
    [SerializeField]
    private int yDragDir = 1;
    [SerializeField]
    private Vector2 _minCamPos = new Vector2(-16,-32);
    [SerializeField]
    private Vector2 _maxCamPos = new Vector2(16,32);

    private Vector3 targetPos; 
    private void ZoomInOut()
    {
        //  마우스 우클릭 중에만 카메라 무빙 적용
        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelspeed;
        if (distance < _minZoom) distance = _minZoom;
        if (distance > _maxZoom) distance = _maxZoom;
        //_mainCam.fieldOfView = distance;

        targetPos.y = distance; 

        if (Input.GetMouseButton(2))
        {
            x += Input.GetAxis("Mouse X") * _moveSpeed * Time.unscaledDeltaTime; // 마우스의 좌우 이동량을 xmove 에 누적
            y += Input.GetAxis("Mouse Y") * _moveSpeed * Time.unscaledDeltaTime; // 마우스의 상하 이동량을 ymove 에 누적

            targetPos = new Vector3(x * xDragDir, targetPos.y , y * yDragDir);
            //transform.position = Vector3.SmoothDamp(transform.position, reverseDistance, ref velocity, SmoothTime);
        }
        if(Input.GetMouseButtonUp(2))
        {
            CheckCamPos();
            x = Mathf.Clamp(x, _minCamPos.x, _maxCamPos.x);
            y = Mathf.Clamp(y, _minCamPos.y, _maxCamPos.y);
        }
        transform.position = targetPos;

    }

    private void CheckCamPos()
    {
        if (transform.position.x < _minCamPos.x)
        {
            targetPos.x = _minCamPos.x;
        }
        if (transform.position.x > _maxCamPos.x)
        {
            targetPos.x = _maxCamPos.x;
        }
        if (transform.position.z < _minCamPos.y)
        {
            targetPos.z = _minCamPos.y;
        }
        if (transform.position.z > _maxCamPos.y)
        {
            targetPos.z = _maxCamPos.y;
        }

        transform.DOMove(targetPos, 0.5f);
        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, SmoothTime);
    }

    #region 음
    /*
    private void ChangeViewType()
    {
        if (_curViewType == ViewType.Topdown)
        {
            _curViewType = ViewType.Moving;
            return;
        }
        _curViewType = ViewType.Topdown;

        _mainCam.transform.position = _originPos;
        _mainCam.transform.eulerAngles = _originRot;
    }

    
    private float _rotY, _rotX = 90;
    private void MoveCam()
    {

        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");

        _rotX += x;
        _rotX = Mathf.Clamp(_rotX, -90, 90);
        _rotY += y;
        _mainCam.transform.eulerAngles = new Vector3(-_rotX, _rotY,0);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _mainCam.transform.position += new Vector3(h, 0, v); 
    }
    private void FixedCamera()
    {
        if (Input.GetMouseButton(2))
        {
            x += Input.GetAxis("Mouse X") * _moveSpeed * Time.unscaledDeltaTime; // 마우스의 좌우 이동량을 xmove 에 누적
            y += Input.GetAxis("Mouse Y") * _moveSpeed * Time.unscaledDeltaTime; // 마우스의 상하 이동량을 ymove 에 누적

            Vector3 reverseDistance = new Vector3(x, 20, y);
            transform.position = reverseDistance;
            //Vector3.SmoothDamp(transform.position, player.transform.position - transform.rotation * reverseDistance, ref velocity, SmoothTime);
        }
    }

    */

    #endregion
}
