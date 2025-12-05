using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    public void AddForce(List<Rigidbody> cubes, RaycastHit hit)
    {
        foreach (Rigidbody cube in cubes)
            cube.AddExplosionForce(_explosionForce, hit.transform.position, _explosionRadius);
    }
}
