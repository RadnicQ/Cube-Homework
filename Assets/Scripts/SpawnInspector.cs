using System.Collections.Generic;
using UnityEngine;

public class SpawnInspector : MonoBehaviour
{
    private Raycaster _raycaster;
    private Spawner _spawner;
    private Exploder _exploder;
    private int _minimumChance = 0;
    private int _maximumChance = 100;

    private void Awake()
    {
        _raycaster = Camera.main.GetComponent<Raycaster>();
        _spawner = GetComponent<Spawner>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnEnable() =>
        _raycaster.HitInfo += RaycastProcessing;

    private void OnDisable() =>
        _raycaster.HitInfo -= RaycastProcessing;

    private void RaycastProcessing(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out Clonable clonable))
        {
            if (IsSuccessfulChance(clonable))
            {
                List<Rigidbody> spawners = _spawner.GetSpawnablesRaycastHitObject(hit);
                _exploder.AddForce(spawners, hit);
            }

            Destroy(hit.collider.gameObject);
        }
    }

    private bool IsSuccessfulChance(Clonable clonable)
    {
        int randomNumber = Random.Range(_minimumChance, _maximumChance + 1);
        int spawnChance = clonable.DivideChance;

        return randomNumber < spawnChance;
    }
}
