using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSpawner : TrapAbstract
{
    public override IEnumerator SpawnTrap()
    {
        Instantiate(trapToSpawn,transform.position,Quaternion.identity); //Spawn alert of arrow
        yield return new WaitForSeconds(4f); //wait for new trap spawn
        TrapManager.trapInst.canSpawn = true; // spawn trap again

    }
    public override void TileTrap(Vector2 pos)
    {
        if (trap.overTile) //can't spawn alert because trap.overtile is falses
        {
            Instantiate(trapToSpawn, transform.position, Quaternion.identity);
        }
    }
}
