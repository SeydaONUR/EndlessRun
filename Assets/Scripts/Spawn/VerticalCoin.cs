using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCoin : SpawnAbstract
{
    public static VerticalCoin instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        canSpawn = true;
    }
    //Vertical Spawn
    public override void Spawn()
    {
        CoinSpawner.instance.canSpawn = false;
        Debug.Log("Vertical");
        StartCoroutine(Vertical(spawnPoint.position, Random.Range(2, 4),false));
    }
    public IEnumerator Vertical(Vector2 point,int number,bool first) 
    {
        Debug.Log("Vertical");
        for (int i=0; i<number; i++)
        {
            Instantiate(objectToSpawn, point, Quaternion.identity);
            point = new Vector2(point.x, point.y + 0.7f);
        }
        yield return new WaitForSeconds(0.55f);
        if (first == true)
        {
            TileSpawner2.inst.canSpawn = true; //creat again
        }
        else // created coin
        {
            CoinSpawner.instance.spawnCounter += 1;
            CoinSpawner.instance.canSpawn = true; //creat coin
        }
    }

}
