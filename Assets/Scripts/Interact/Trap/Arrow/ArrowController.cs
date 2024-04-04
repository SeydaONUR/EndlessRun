using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour, IInteractable
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
         rb.velocity = Vector2.left * speed; // Arrow moves left
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject); //destroy when become invisible
    }
    public void Interact()
    {
        InteractManager.interactInstance.Arrow();
        Destroy(gameObject); //player break arrow
        // you can add animation to break 
    }
}
