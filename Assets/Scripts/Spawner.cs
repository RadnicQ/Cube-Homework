using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Rigidbody _spawnObject;
    private int _minimumObjectSpawnCount = 2;
    private int _maximumObjectSpawnCount = 6;
    private float _downScaleValue = 0.5f;

    public List<Rigidbody> GetSpawnablesRaycastHitObject(Clonable clonoble)
    {
        List<Rigidbody> spawnObjects = new();
        int cubeCount = Random.Range(_minimumObjectSpawnCount, _maximumObjectSpawnCount + 1);
        int divideChance = clonoble.DivideChance / clonoble.DivisionFactor;
        Vector3 spawnObjectScale = clonoble.transform.localScale * _downScaleValue;
        _spawnObject = clonoble.GetComponent<Rigidbody>();

        for (int i = 0; i < cubeCount; i++)
        {
            spawnObjects.Add(Instantiate(_spawnObject, clonoble.transform.position, clonoble.transform.rotation));
            spawnObjects[i].GetComponent<Clonable>().Initialize(divideChance, spawnObjectScale);
        }

        return spawnObjects;
    }
}
