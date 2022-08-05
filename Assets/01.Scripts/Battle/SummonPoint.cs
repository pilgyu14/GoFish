using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPoint : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private Material _redMat;
    [SerializeField]
    private Material _greenMat;
    private MeshRenderer _meshRenderer;

    private BattleManager _battleManger;
    private Vector3 _mousePos;
    private Ray _ray;
    private RaycastHit _hitInfo;


    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _battleManger = FindObjectOfType<BattleManager>(); 
    }
    void Update()
    {
        MoveMousePoint(); 
    }

    /// <summary>
    /// 마우스포인트로 이동 
    /// </summary>
    private void MoveMousePoint()
    {
        _ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hitInfo))
        {
            _mousePos = _hitInfo.point;
            // _mousePos.y = 0.06f;
            transform.position = _hitInfo.point;

            if (_hitInfo.collider.CompareTag("Water")) // 물이면 소환 가능 
            {
                _meshRenderer.material = _greenMat;
                _battleManger.SummonComponent.IsSummonable = true; 
                return; 
            }
            else if(_hitInfo.collider.CompareTag("Ground"))
            {
                _battleManger.SummonComponent.IsSummonable = false;
                _meshRenderer.material = _redMat;
            }
      
        }
    
    }
}
