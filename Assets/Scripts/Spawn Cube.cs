using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    private ClickMouse _clickMouse;
    private Rigidbody _spawnObject;
    public event Action<List<Rigidbody>> SpawnObjects;
    private int _minimumObjectSpawnCount = 2;
    private int _maximumObjectSpawnCount = 6;
    private int _minimumChance = 0;
    private int _maximumChance = 100;
    private int _downgradeChance = 2;
    private int _spawnChance = 100;
    private float _downScaleValue = 0.5f;

    private void Awake()
    {
        _clickMouse = Camera.main.GetComponent<ClickMouse>();
    }

    private void OnEnable() =>
        _clickMouse.OnClick += InstantiateCube;

    private void OnDisable() =>
        _clickMouse.OnClick -= InstantiateCube;

    private void InstantiateCube(RaycastHit hit)
    {
        int randomNumber = UnityEngine.Random.Range(_minimumChance, _maximumChance + 1);

        if (randomNumber > _spawnChance)
        {
            Destroy(hit.collider.gameObject);
            return;
        }

        List<Rigidbody> spawnObjects = new();
        int cubeCount = UnityEngine.Random.Range(_minimumObjectSpawnCount, _maximumObjectSpawnCount + 1);

        _spawnChance /= _downgradeChance;
        _spawnObject = hit.collider.attachedRigidbody;
        _spawnObject.transform.localScale = hit.transform.localScale * _downScaleValue;

        for (int i = 0; i < cubeCount; i++)
        {
            spawnObjects.Add(Instantiate(_spawnObject, hit.transform.position, hit.transform.rotation));
        }

        SpawnObjects?.Invoke(spawnObjects);
    }
}
