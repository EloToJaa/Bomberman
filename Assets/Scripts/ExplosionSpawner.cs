using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ExplosionSpawner : MonoBehaviour
{
    public static ExplosionSpawner Instance { get; private set; }
    public static LayerMask DESTRUCTIBLE_LAYER_MASK { get => LayerMask.NameToLayer("DestructibleTiles"); }

    [Header("Explosion")]
    [SerializeField] private LayerMask allWallsLayerMask;
    [SerializeField] private GameObject explosionPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(gameObject);
    }

    public void StartExplosion(Vector3 position, int explosionRadius = 2)
    {
        position = HelperFunctions.NormalizePosition(position);
        SpawnExplosion(position);
        TryToExplode(position, Vector3.forward, explosionRadius);
        TryToExplode(position, Vector3.back, explosionRadius);
        TryToExplode(position, Vector3.left, explosionRadius);
        TryToExplode(position, Vector3.right, explosionRadius);
    }

    private void TryToExplode(Vector3 position, Vector3 direction, int length)
    {
        // przerywamy pozosta�a d�ugo�� eksplozji jest <= 0
        if (length <= 0) return;
        // dodajemy do pozycji kierunek
        // (jest d�ugo�ci 1 i skierowany g�ra/d�/lewo/prawo)
        position += direction;
        // sprawdzamy czy s� jakie� mury na pozycji - je�li tak to przerywamy
        if (CheckForWalls(position)) return;
        // je�li mur�w nie ma spawnujemy eksplozj�
        SpawnExplosion(position);
        // pr�bujemy postawi� nast�pn� eksplozj� w tym samym kierunku
        TryToExplode(position, direction, length - 1);
    }

    private void SpawnExplosion(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }

    bool CheckForWalls(Vector3 position)
    {
        GameObject wall = HelperFunctions.CheckForCollision(position, allWallsLayerMask);
        if (wall == null) return false;

        if (wall.layer == DESTRUCTIBLE_LAYER_MASK)
        {
            Destroy(wall);
        }
        return true;
    }
}
