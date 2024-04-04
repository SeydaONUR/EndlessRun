using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAbstract : MonoBehaviour 
{
    public Transform spawnPoint;
    public GameObject objectToSpawn; //spawn object
    public bool canSpawn;
    public abstract void Spawn(); 
}
