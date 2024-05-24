using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombController : MonoBehaviour
{
    [Header("Key bindings")]
    [SerializeField] private KeyCode inputKey = KeyCode.Space;

    [Header("Bomb parameters")]
    [SerializeField] private  int bombAmount = 1;
    [SerializeField] private int explosionRadius = 2;
    public int GetExplosionRadius() => explosionRadius;

    private int bombsRemaining;
    private bool stayOnBomb = false;
    
    private void Awake()
    {
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombsRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            PlaceBomb();
        }
    }

    private void PlaceBomb()
    {
        // przerywamy jeœli gracz stoi na bombie
        
        // zmniejszamy liczbê dostêpnych bomb
        
        // stawiamy bombê korzystaj¹c z BombSpawnera
        // podajemy w³asn¹ aktualn¹ pozycjê
        
        // ustawiamy ¿e stoimy na bombie aby zapobiec
        // stawianiu kolejnej do czasu odejœcia z kolejnej
        
    }
}
