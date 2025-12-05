using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]

public class Clonable : MonoBehaviour
{
    public int DivisionFactor { get; private set; } = 2;
    public int DivideChance { get; private set; } = 100;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void Initialization(int divideChance, Vector3 scaleValue)
    {
        DivideChance = divideChance;
        transform.localScale = scaleValue;
    }
}