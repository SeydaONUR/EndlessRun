using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TrampolineSpawner : SpawnAbstract
{
    public static TrampolineSpawner instance;
    //

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        Spawn();
    }
    public override void Spawn()
    {
        Debug.Log("TRAMPOLINEEEEEEEEEEEEEEEEEE");
        Instantiate(objectToSpawn,spawnPoint.position,Quaternion.identity);
    }
}
