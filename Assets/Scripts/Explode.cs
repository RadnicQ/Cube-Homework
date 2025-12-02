using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    private SpawnCube _spawnCube;
    private RaycastHit _hit;
    private ClickMouse _clickMouse;

    private void Awake()
    {
        _clickMouse = Camera.main.GetComponent<ClickMouse>();
        _spawnCube = GetComponent<SpawnCube>();
    }

    private void OnEnable()
    {
        _clickMouse.OnClick += HitInfo;
        _spawnCube.SpawnObjects += AddForce;
    }

    private void OnDisable()
    {
        _clickMouse.OnClick -= HitInfo;
        _spawnCube.SpawnObjects -= AddForce;
    }

    private void AddForce(List<Rigidbody> cubes)
    {
        foreach (Rigidbody cube in cubes)
            cube.AddExplosionForce(_explosionForce, _hit.transform.position, _explosionRadius);

        Destroy(_hit.collider.gameObject);
    }

    private void HitInfo(RaycastHit hit) =>
        _hit = hit;
}
