using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPoint : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;

    private Vector3 _mousePos;
    private Ray _ray;
    private RaycastHit _hitInfo;
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
            _mousePos.y = 0.06f;
            transform.position = _hitInfo.point;
        }
    }
}
