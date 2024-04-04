using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manage : MonoBehaviour
{
    public static Manage manageInst;
    public float speed;
    public bool isDashing;
    public event Action dashPlayer;
    private void Awake()
    {
        if (manageInst != null)
        {
            Destroy(gameObject);
        }
        else
        {
            manageInst = this;
        }
    }
    private void Start()
    {
        isDashing = false;
    }
    private void Update()
    {
        if (Input.touchCount > 0 && DashController.dashInst.canDash == true) // touch to dash
        {
            Touch touch = Input.GetTouch(0);
            if (touch.deltaPosition.x > 50f)
            {
                StartCoroutine(dash()); //dash
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDashing) // move
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 30f, GetComponent<Rigidbody2D>().velocity.y); //dash speed
            dashPlayer?.Invoke(); //call player action
        }
        else
        {
            transform.position = new Vector3(transform.position.x + speed, 0f, 0f); // Increase speed for camera,player etc.
        }

    }
    private IEnumerator dash()
    {
        DashController.dashInst.canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(0.3f);
        DashController.dashInst.canDash = true; //add super bar later. bar will fill with coin
        isDashing = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); //after dash reset velocity
    }
}
