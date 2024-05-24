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

    public void PlaceBomb(Vector3 position)
    {
        // znormalizuj podan¹ w parametrze pozycjê u¿ywaj¹c
        // metody NormalizePosition() z klasy HelperFunctions
        position = HelperFunctions.NormalizePosition(position);

        // stwórz obiekt bomby na scenie w znormalizowanej pozycji
        Instantiate(bombPrefab, position, Quaternion.identity);
    }
}
