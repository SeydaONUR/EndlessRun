using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : TrapAbstract
{
    public override IEnumerator SpawnTrap()
    {
        Instantiate(trapToSpawn,spawnPos.position,Quaternion.identity);
        yield return new WaitForSeconds(4f);
        TrapManager.trapInst.canSpawn = true;
    }

    public override void TileTrap(Vector2 pos)
    {
        if (trap.overTile) //rock can be on tile
        {
            Instantiate(trapToSpawn, new Vector2(pos.x, pos.y + 0.28f), Quaternion.identity);
        }
    }
}
