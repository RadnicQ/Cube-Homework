using System;
using UnityEngine;

[RequireComponent(typeof(Clicker))]

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _rayDistanse = 100f;

    private Camera _mainCamera;
    private Clicker _clickMouse;
    private Ray _ray;
    private RaycastHit _hit;

    public event Action<RaycastHit> HitInfo;

    private void Awake()
    {
        _clickMouse = GetComponent<Clicker>();
        _mainCamera = Camera.main;
    }

    private void OnEnable() =>
        _clickMouse.Click += SetOffRay;

    private void OnDisable() =>
        _clickMouse.Click -= SetOffRay;

    private void SetOffRay()
    {
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, _rayDistanse))
            HitInfo?.Invoke(_hit);
    }
}
