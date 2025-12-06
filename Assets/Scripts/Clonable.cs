using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]

public class Clonable : MonoBehaviour
{
    public int DivisionFactor { get; private set; } = 2;
    public int DivideChance { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void Initialize(int divideChance, Vector3 scaleValue)
    {
        DivideChance = divideChance;
        transform.localScale = scaleValue;
    }
}