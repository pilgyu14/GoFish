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

    private Vector3 _originPos, _originRot;
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
        if(isMove == true)
        {
            return; 
        }

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
        if (Input.GetKeyDown(KeyCode.Q))
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
    private Vector2 _minCamPos = new Vector2(-16, -32);
    [SerializeField]
    private Vector2 _maxCamPos = new Vector2(16, 32);

    private Vector3 targetPos; // X : 카메라 좌우 Y : 카메라 높이 Z : 카메라 앞뒤 
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


            targetPos = new Vector3(x * xDragDir, targetPos.y, y * yDragDir);
            //transform.position = Vector3.SmoothDamp(transform.position, reverseDistance, ref velocity, SmoothTime);
        }
        if (Input.GetMouseButtonUp(2))
        {
            CheckCamPos();
            x = Mathf.Clamp(x, _minCamPos.x, _maxCamPos.x);
            y = Mathf.Clamp(y, _minCamPos.y, _maxCamPos.y);
        }
    
        if (isMove == true) return; 
       transform.localPosition = targetPos;

    }

    [SerializeField]
    private Ease ease;
    [SerializeField]
    private float time = 1f;

    private bool isMove = false;
    private void CheckCamPos()
    {
        if (transform.localPosition.x < _minCamPos.x)
        {
            targetPos.x = _minCamPos.x;
            isMove = true;
        }
        if (transform.localPosition.x > _maxCamPos.x)
        {
            targetPos.x = _maxCamPos.x;
            isMove = true;
        }
        if (transform.localPosition.z < _minCamPos.y)
        {
            targetPos.z = _minCamPos.y;
            isMove = true;
        }
        if (transform.localPosition.z > _maxCamPos.y)
        {
            targetPos.z = _maxCamPos.y;
            isMove = true;
        }

        if(isMove == true)
        {
            //StartCoroutine(MoveLimitPos());
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DOLocalMove(targetPos, time).SetEase(ease));
            seq.AppendCallback(() => isMove = false);
        }

        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, SmoothTime);
    }

    [Header("테스트 스피드"), SerializeField]
    private float _testSpeed = 10f; 
    IEnumerator MoveLimitPos()
    {
        while((transform.localPosition - targetPos).sqrMagnitude > 0.01f)
        {
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, _testSpeed * Time.deltaTime);
                yield return null; 
        }
        isMove = false; 
    }
  
}
