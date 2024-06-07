using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static LayerMask BOMB_LAYER_MASK { get => LayerMask.NameToLayer("Bomb"); }

    [SerializeField] private float fuseTime = 3f;

    private BombController owner;
    public void SetOwner(BombController owner) => this.owner = owner;

    private MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    public void Start()
    {
        Invoke(nameof(Explode), fuseTime);
    }

    public void Explode()
    {
        CancelInvoke(); // potrzebne do nastêpnej lekcji
        // stwórz eksplozjê, przeka¿ rozmiar od w³aœciciela bomby
        ExplosionSpawner.Instance.StartExplosion(transform.position, owner.GetExplosionRadius());
        // zwiêksz w³aœcicielowi liczbê dostêpnych bomb
        owner.IncreaseBombsRemaining();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;

        if (layer == PlayerController.PLAYER_LAYER_MASK)
        {
            Vector3 playerDirection = collision.gameObject.GetComponent<MovementController>().Direction;
            movementController.SetDirection(playerDirection);
        }
        else if (layer == BOMB_LAYER_MASK)
        {
            movementController.SetDirection(Vector3.zero);
            movementController.Rigidbody.velocity = Vector3.zero;
        }
    }
}
