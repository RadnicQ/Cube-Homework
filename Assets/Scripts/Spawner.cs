using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Rigidbody _spawnObject;
    private int _minimumObjectSpawnCount = 2;
    private int _maximumObjectSpawnCount = 6;
    private float _downScaleValue = 0.5f;

    public List<Rigidbody> InstantiateCube(RaycastHit hit)
    {
        List<Rigidbody> spawnObjects = new();
        int cubeCount = UnityEngine.Random.Range(_minimumObjectSpawnCount, _maximumObjectSpawnCount + 1);

        _spawnObject = hit.collider.attachedRigidbody;
        _spawnObject.transform.localScale = hit.transform.localScale * _downScaleValue;

        for (int i = 0; i < cubeCount; i++)
        {
            spawnObjects.Add(Instantiate(_spawnObject, hit.transform.position, hit.transform.rotation));
        }

        return spawnObjects;
    }
}
