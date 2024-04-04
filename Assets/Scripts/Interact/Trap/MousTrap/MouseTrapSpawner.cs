using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrapSpawner : TrapAbstract
{
    public override IEnumerator SpawnTrap()
    {
        Instantiate(trapToSpawn,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(4f); //wait for spawn tile again
        TrapManager.trapInst.canSpawn = true;
    }

    public override void TileTrap(Vector2 pos)
    {
        if (trap.overTile) // mousetrap can be on tile
        {
            Instantiate(trapToSpawn, new Vector2(pos.x, pos.y + 0.2f), Quaternion.identity);
        }
    }
}
