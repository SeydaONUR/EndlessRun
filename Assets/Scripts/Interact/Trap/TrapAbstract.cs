using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapAbstract : MonoBehaviour
{
    public Transform spawnPos; //for trap pos
    public GameObject trapToSpawn; //which object spawn
    public ScriptableTrap trap; //for take properties
    public abstract IEnumerator SpawnTrap(); //for spawn 
    public abstract void TileTrap(Vector2 pos); //create trap on tile
}
