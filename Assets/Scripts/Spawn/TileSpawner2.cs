using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner2 : SpawnAbstract
{
    public static TileSpawner2 inst;
    public int counter;
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
        counter = 0;
    }
    void Start()
    {
        Trampoline.tramp.tileTrampoline += trampolineTile;
    }
    private void Update()
    {
        if (canSpawn && counter <=3) 
        {
            canSpawn = false;
            Spawn();
        }
    
    }
    public override void Spawn()
    {
        if (counter <3) //can creat max 3 tile
        {
            StartCoroutine(spawnTile(Random.Range(0, 3), spawnPoint.position));
        }
        else //create some coin
        {
            canSpawn = false;
            counter = 0;
            CoinSpawner.instance.canSpawn = true;
        }
    }
    private IEnumerator spawnTile(int numberOfTile,Vector2 pos)
    {
        counter += 1;
        for (int i=0; i <= numberOfTile; i++) //we creat 1,2 or 3 tile 
        {
            Instantiate(objectToSpawn, pos, Quaternion.identity);
            pos = new Vector2(pos.x + 2f,pos.y+2.5f);
        }
        yield return new WaitForSeconds(2f);
        canSpawn = true; //spawn tile again
    }
    private void trampolineTile(Vector2 pos)
    {
        Instantiate(objectToSpawn, new Vector2(pos.x + 3f, pos.y + 4.5f), Quaternion.identity); //creat tile when created trampoline
    }


}
