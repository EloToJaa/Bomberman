using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSpawner : MonoBehaviour
{
    public static PickupsSpawner Instance { get; private set; }

    [SerializeField] private Transform[] pickupPrefabs;
    [Range(0f, 1f)]
    [SerializeField] private float spawnChance = 0.33f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(gameObject);
    }

    private void SpawnPickup( Transform prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }
}
