using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DashController : PowerUpAbstract
{
    public static DashController dashInst;
    public TrailRenderer trail; //for animation
    public bool dashing; //for interact and animation
    public Transform dashPoint; //konumu kaybetmemek icin
    public bool canDash;
    public event Action addEnemy;
    private void Awake()
    {
        //trail.emitting = false;
        if (dashInst != null)
        {
            Destroy(gameObject);
        }
        else
        {
            dashInst = this;
        }

    }
    void Start()
    {
        trail.emitting = false;
        Manage.manageInst.dashPlayer += dash;
    }
    void Update()
    {
        if (Manage.manageInst.isDashing ==true)
        {
           GetComponentInParent<Transform>().position = new Vector2(dashPoint.transform.position.x, transform.position.y); //dash yapiyorsak sürekli bu konuma kendini sabitle
        }
    }
    public override void takePower() // if we take dash power up
    {
        Debug.Log("Can dash: " + canDash);
        canDash = true;
        addEnemy?.Invoke(); // for add enemy trap spawner list. We only spawn enemy we can dash
        PlayerController.Instance.anim.Play("Mickey_Run_Sword"); //change animation
        PlayerController.Instance.anim.SetBool("Sword",true);
    }
    private void dash()
    {
        StartCoroutine(playerDash());
    }
    IEnumerator playerDash()
    {
        PlayerController.Instance.anim.SetBool("Dash", dashing); // for animation
        PlayerController.Instance.rb.gravityScale = 0f; // fix horizontal axis
        dashing = true;
        trail.emitting = true; // back line
        PlayerController.Instance.rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(0.4f);
        dashing = false;
        PlayerController.Instance.anim.SetBool("Dash", dashing);
        trail.emitting = false;
        PlayerController.Instance.rb.gravityScale = 1f;
    }

    
}
