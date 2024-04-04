using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trampoline : MonoBehaviour
{
    public static Trampoline tramp;
    public event Action<Vector2> coinTrampoline;
    public event Action<Vector2> tileTrampoline;
    private void Awake()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        if (tramp == null)
        {
            tramp = this;
        }else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coinTrampoline?.Invoke(transform.position);
        tileTrampoline?.Invoke(transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player" && PlayerController.Instance.onGround() == false)
        {
            PlayerController.Instance.trampolineJump(PlayerController.Instance.falling);
            PlayerController.Instance.falling = false; //tekrar yere dogru dusmesin
        }
       
    }
}
