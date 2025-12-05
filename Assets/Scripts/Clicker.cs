using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private readonly int _inputKay = 0;

    public event Action Click;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_inputKay))
            Click?.Invoke();
    }
}
