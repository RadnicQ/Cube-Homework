using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Spawner), typeof(Exploder))]

public class SpawnInspector : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    private Camera _mainCamera;
    private Spawner _spawner;
    private Exploder _exploder;
    private int _minimumChance = 0;
    private int _maximumChance = 100;

    private void Awake()
    {
        _mainCamera = Camera.main;
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
                List<Rigidbody> spawners = _spawner.GetSpawnablesRaycastHitObject(clonable);
                _exploder.AddForce(spawners, hit);
            }
            else
            {
                _exploder.AddForce(hit);
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
