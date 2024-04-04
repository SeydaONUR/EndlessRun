using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public Renderer render;
    public float backgroundSpeed;

    private void Update()
    {
        render.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f); //to move background infinitly

        /*if (Manage.manageInst.isDashing)
        {
            render.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime*2f, 0f);  // move faster
        }
        else
        {
            render.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f); 

        }*/
    }
}