using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : TrapAbstract
{
    public static EnemySpawner inst;
    private void Awake()
    {
        if (inst==null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public override IEnumerator SpawnTrap()
    {
        Instantiate(trapToSpawn,transform.position,Quaternion.identity); //spawn enemy
        yield return new WaitForSeconds(4f); 
        TrapManager.trapInst.canSpawn = true; // spawn trap again
    }

    public override void TileTrap(Vector2 pos)
    {
        if (trap.overTile) // enemy can be on tile
        {
            Instantiate(trapToSpawn, new Vector2(pos.x, pos.y + 0.75f), Quaternion.identity);
        }
    }
}
