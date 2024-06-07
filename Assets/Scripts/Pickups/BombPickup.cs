using UnityEngine;

public class BombPickup : Pickup
{
    [SerializeField] private int bombAmountIncrease = 1;

    protected override void Picked(GameObject player)
    {
        player.GetComponent<BombController>().IncreaseBombAmount(bombAmountIncrease);
        base.Picked(player);
    }
}
