using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private BoxCollider2D tileCol; // collider of tile
    public bool onPlayer; // is player on tile
    private int size; 
    private void Awake()
    {
        tileCol = GetComponent<BoxCollider2D>();
        tileCol.isTrigger = true;
        size = Random.Range(3,10); //size of tile
        generateTile(size);
    }
    private void Start()
    {
        int rand = Random.Range(1, 51);
        if (rand < 15) //burada belirli araliklarla tile in ustunde coin ve enemy olusturdum
        {
            CoinSpawner.instance.tileCoin(new Vector2(transform.position.x, transform.position.y + 0.7f));
            if (rand<7 && size>5)
            {
                TrapManager.trapInst.tileEnemy(new Vector2(transform.position.x+1.5f,transform.position.y));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        changeTrigger();
        if (onPlayer  && PlayerController.Instance.falling ) //tile'in ustunde isen trigger i aktifleþtir yukaridan düþersen aktif olmaz
        {
            tileCol.isTrigger = true;
        }
    }
    private void changeTrigger()
    {
        if (PlayerController.Instance.GetComponentInChildren<BoxCollider2D>().bounds.max.y< tileCol.bounds.max.y) 
        {
            tileCol.isTrigger = true; // player ýn pozisyonu tile dan küçükse trigger ý aktif et
        }
    }
    public void generateTile(float size)
    {    
        gameObject.transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z); //change size of tile
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Middle") //Middle player in asagisinda olusturdugum bir box collider
        {
            PlayerController.Instance.falling = false; // only pass a tile 
            tileCol.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player" ) 
        {
            onPlayer = true; // player on tile. If we scroll down player fall from on the tile
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onPlayer = false;
        }
    }
    private void OnBecameInvisible() //when tile become invisible destroy it
    {
        Destroy(gameObject);
    }
}
