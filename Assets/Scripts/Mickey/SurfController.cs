using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfController : MonoBehaviour
{
    public bool isSurfing;
    private int counter;
    private void FixedUpdate()
    {
        // I changed gravity in fixedUpdate because fixed update better than update physics calculation
        if (isSurfing)
        {
            PlayerController.Instance.rb.gravityScale = 0.1f; //player is surfing fall slowly
        }
        else
        {
            PlayerController.Instance.rb.gravityScale = 1f; // fall normal speed
        }
    }
    private void Update()
    {
        if (!PlayerController.Instance.onGround() && PlayerController.Instance.rb.velocity.y < 0 && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) 
            // when surfing on player top and touch screen
        {
            counter++;
            Surfing();
            Debug.Log("Ýyi gir");
            PlayerController.Instance.anim.SetBool("Surfing", isSurfing);
        }
        if (isSurfing)
        {
            if (PlayerController.Instance.onGround() || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) // when stopping touch
            {
                counter--;
                cancelSurfing();
                PlayerController.Instance.anim.SetBool("Surfing", isSurfing);
            }
        }
    }
    private void Surfing()
    {
        isSurfing = true;

    }
    private void cancelSurfing()
    {
        isSurfing = false;
    }
}
