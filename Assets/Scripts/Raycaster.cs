using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _rayDistanse = 100f;

    private Clicker _clickMouse;
    private Ray _ray;
    private RaycastHit _hit;

    public event Action<RaycastHit> HitInfo;

    private void Awake()
    {
        _clickMouse = GetComponent<Clicker>();
    }

    private void OnEnable() =>
        _clickMouse.OnClick += SetOffRay;

    private void OnDisable() =>
        _clickMouse.OnClick -= SetOffRay;

    private void SetOffRay()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, _rayDistanse))
            HitInfo?.Invoke(_hit);
    }
}
