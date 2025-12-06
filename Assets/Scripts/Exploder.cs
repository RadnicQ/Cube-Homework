using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Exploder : MonoBehaviour
{
    private const float s_standartValueFactor = 1f;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void AddForce(List<Rigidbody> cubes, RaycastHit hit, float valueFactor = s_standartValueFactor)
    {
        foreach (Rigidbody cube in cubes)
            cube.AddExplosionForce(_explosionForce / valueFactor, hit.transform.position, _explosionRadius / valueFactor);
    }

    public void AddForce(RaycastHit hit)
    {
        float valueFactor = hit.transform.localScale.x;
        List<Rigidbody> cubes = Physics.OverlapSphere(hit.transform.position, _explosionRadius / valueFactor, hit.collider.layerOverridePriority).Select(collider => collider.attachedRigidbody).Where(rigitBody => rigitBody != null).ToList();
        AddForce(cubes, hit, valueFactor);
    }
}
