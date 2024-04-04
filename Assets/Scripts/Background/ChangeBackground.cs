using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Transform changeTransform;
    private Vector2 startPos;
    private BoxCollider2D box; //sprite size
    public GameObject[] sprites;
    private float boundSize;
    // Start is called before the first frame update
    private void Awake()
    {
        startPos = changeTransform.position;
        box = GameObject.Find("Collider").GetComponent<BoxCollider2D>();
        float randomBound = Random.Range(3, 6); 
        boundSize = (box.bounds.max.x - box.bounds.min.x) * randomBound; // sprite size multiply random number

    }
    void Start()
    {
    }
    private void FixedUpdate()
    {
        float distance = Vector2.Distance(startPos, changeTransform.position); //ChangeTransform move together manage script
        if (distance >= boundSize)
        {
            changeBackground();
        }
    }

    private void changeBackground()
    {
        int random = Random.Range(0, 2); // New random number for change
        sprites[random].SetActive(true);
        for (int i = 0; i < 2; i++)
        {
            if (i == random)
            {
                sprites[i].SetActive(true); //change BG
            }
            else
                sprites[i].SetActive(false);
        }

        startPos = new Vector2(box.bounds.min.x, startPos.y); //change start pos because if we didn't change always changeBG

    }
}

