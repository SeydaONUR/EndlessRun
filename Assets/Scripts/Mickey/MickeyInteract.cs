using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MickeyInteract : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D collision)// for player trigger a interactable objects
    {
        IInteractable interact = collision.GetComponent<IInteractable>();
        if (interact != null)
        {
            interact.Interact();
        }
    }
    private void OnCollisionEnter2D(Collision2D col) // for player collision a interactable objects
    {
        IInteractable Interact =col.gameObject.GetComponent<IInteractable>();
        if (Interact != null)
        {
            Interact.Interact();
        }
    }
}
