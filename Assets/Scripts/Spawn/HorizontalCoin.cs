using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCoin : SpawnAbstract
{
    public LayerMask tile;
    public static HorizontalCoin instance;
    private void Awake()
    {

        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        canSpawn = true;
    }
    public override void Spawn()
    {
        CoinSpawner.instance.canSpawn = false; //Can't create coin again
        StartCoroutine(Horizontal(transform.position, Random.Range(2, 4),false));
    }
    public IEnumerator Horizontal(Vector2 point, int number,bool first)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(objectToSpawn, point, Quaternion.identity);
            point = new Vector2(point.x+0.7f, point.y );
        }
        yield return new WaitForSeconds(0.55f); //wait for create again
        if (first == true)
        {
            TileSpawner2.inst.canSpawn = true; //if we created first coin can spawn tile
        }
        else // created coin 
        {
            CoinSpawner.instance.spawnCounter += 1; 
            CoinSpawner.instance.canSpawn = true; // create coin again
        }
    }
}
