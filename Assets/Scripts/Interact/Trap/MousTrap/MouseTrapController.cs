using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrapController : MonoBehaviour, IInteractable
{
    private void Awake()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,0f);
    }
    public void Interact()
    {
        InteractManager.interactInstance.MouseTrap();
        Destroy(gameObject);
    }

   
}
