using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    
    public static BombSpawner Instance { get; private set; }

    [SerializeField] private GameObject bombPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(gameObject);
    }

    public void PlaceBomb(Vector3 position, BombController owner)
    {
        position = HelperFunctions.NormalizePosition(position);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bomb.GetComponent<Bomb>().SetOwner(owner);
    }
}
