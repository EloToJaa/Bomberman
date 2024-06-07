using UnityEngine;

public class RangePickup : Pickup
{
    [SerializeField] private int rangeIncrease = 1;

    protected override void Picked(GameObject player)
    {
        player.GetComponent<BombController>().IncreaseExplosionRadius(rangeIncrease);
        base.Picked(player);
    }
}
