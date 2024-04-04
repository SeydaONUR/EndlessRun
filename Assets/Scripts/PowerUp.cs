using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, IInteractable
{
    public PowerUpAbstract powerUps; // power up or ups

    public void Interact()
    {
        powerUps.takePower();
        Destroy(gameObject);
    }
}
