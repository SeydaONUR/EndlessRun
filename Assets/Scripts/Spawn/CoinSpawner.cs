using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : SpawnAbstract
{
    public static CoinSpawner instance;
    public SpawnAbstract[] Types; // vertical or horizontal
    public int spawnCounter;
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        spawnCounter = 0;
    }
    void Start()
    {
        Trampoline.tramp.coinTrampoline += TrampolineCoin;
        canSpawn = false; //buralarý bi düzenleyelim gerekirse bakalým.
        StartCoroutine(firstCoin(4, spawnPoint.position)); // we can't create another object when we creat first coin
    }
    void Update()
    {
        if (canSpawn && spawnCounter<=3) // creat coin if coin didn't creat 3 time
        {
            Types[Random.Range(0, Types.Length)].Spawn();
        }
        if (spawnCounter >3) // created more 3 times coim
         {
            canSpawn = false; //can't spawn
            TileSpawner2.inst.canSpawn = true; //spawn tile
            TileSpawner2.inst.counter = 0;
             spawnCounter = 0; 
         }
        if (canSpawn)
        {
            TileSpawner2.inst.canSpawn = false;
        }
    }
    private  IEnumerator firstCoin(int number, Vector2 Pos)
    {
        if (number==3) //  Vertical
        {
            StartCoroutine(VerticalCoin.instance.Vertical(Pos, number, true)); 
            StartCoroutine(VerticalCoin.instance.Vertical(new Vector2(Pos.x + 4f, Pos.y), number, true)); 
        }
        else // Horizontal
        {
            StartCoroutine(HorizontalCoin.instance.Horizontal(Pos, number, true));
            StartCoroutine(HorizontalCoin.instance.Horizontal(new Vector2(Pos.x + 4f, Pos.y), number, true));
            Debug.Log("Burdayým be burdayým");
        }
        yield return new WaitForSeconds(2f);
    }
        
    public override void Spawn()
    {
        //for abstract class
    }
    public void tileCoin(Vector2 pos)
    {
        Instantiate(objectToSpawn,pos,Quaternion.identity); // we can create coin on random tile. 
    }
    private void TrampolineCoin(Vector2 spwn)
    {
        Instantiate(objectToSpawn, new Vector2(spwn.x + 3.7f, spwn.y + 5.2f), Quaternion.identity); // create coin when trampoline created
    }

}
