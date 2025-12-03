using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private readonly int _inputKay = 0;

    [SerializeField] private float _rayDistans;

    public event Action OnClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_inputKay))
            OnClick?.Invoke();
    }
}
