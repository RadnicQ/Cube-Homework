using System;
using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    [SerializeField] float _rayDistans;

    private Ray _ray = new Ray();
    private RaycastHit _hit;

    public event Action<RaycastHit> OnClick;

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, _rayDistans) && Input.GetMouseButtonDown(0) && _hit.collider.TryGetComponent<Clonable>(out Clonable clonable) == true)
            OnClick?.Invoke(_hit);
    }
}
