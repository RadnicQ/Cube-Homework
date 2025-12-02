using UnityEngine;

public class Colorizer : MonoBehaviour
{
    private Renderer _objectRenderer;

    private void Awake()
    {
        Color color = Random.ColorHSV();

        _objectRenderer = GetComponent<Renderer>();
        _objectRenderer.material.color = color;
    }
}
