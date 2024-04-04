using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMain : MonoBehaviour
{
    public GameObject player;
    //Manage normal touch
    void Update()
    {
      if (!PlayerController.Instance.isActiveAndEnabled) //player is dead
       {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             Vector2 touch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
             RaycastHit2D hit = Physics2D.Raycast(touch, Vector2.zero);
             if (hit.collider != null)
              {
                 if (hit.collider.tag == "UI") 
                  {
                    IClickable click = hit.collider.gameObject.GetComponent<IClickable>();
                    if (click != null)
                      {
                        click.Click(); //call ui func 
                      }
                  }
              }
          }
         }
    }
}
