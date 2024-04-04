using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IInteractable
{
    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,0f);
    }
    public void Interact() 
    {
        if (DashController.dashInst.dashing) 
        {
            Destroy(gameObject); // if player is dashing destroy enemy
        }
        InteractManager.interactInstance.Enemy(); // Destroy player
    }
}
