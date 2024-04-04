using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        InteractManager.interactInstance.Rock();
    }

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
