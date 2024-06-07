using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerController.PLAYER_TAG))
        {
            Picked(other.gameObject);
        }
    }

    protected virtual void Picked(GameObject player)
    {
        Destroy(gameObject);
    }
}
