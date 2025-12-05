using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Rigidbody _spawnObject;
    private int _minimumObjectSpawnCount = 2;
    private int _maximumObjectSpawnCount = 6;
    private float _downScaleValue = 0.5f;

    public List<Rigidbody> GetSpawnablesRaycastHitObject(RaycastHit hit)
    {
        List<Rigidbody> spawnObjects = new();
        hit.collider.TryGetComponent(out Clonable clonable);
        int cubeCount = Random.Range(_minimumObjectSpawnCount, _maximumObjectSpawnCount + 1);
        int divideChance = clonable.DivideChance / clonable.DivisionFactor;
        Vector3 spawnObjectScale = hit.transform.localScale * _downScaleValue;

        _spawnObject = hit.collider.attachedRigidbody;

        for (int i = 0; i < cubeCount; i++)
        {
            spawnObjects.Add(Instantiate(_spawnObject, hit.transform.position, hit.transform.rotation));
            spawnObjects[i].TryGetComponent(out Clonable spawningClonable);
            spawningClonable.Initialization(divideChance, spawnObjectScale);
        }

        return spawnObjects;
    }
}
