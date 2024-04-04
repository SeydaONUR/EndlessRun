using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public static TrapManager trapInst;
    public List<TrapAbstract> traps;
    public TrapAbstract enemy; //if we take power up, game spawns enemy
    public bool canSpawn;
    private void Awake()
    {
        if (trapInst == null)
        {
            trapInst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DashController.dashInst.addEnemy += addList; 

    }
    private void addList()
    {
        traps.Insert(traps.Count,enemy); // when take power up add enemy to list
    }

    public void tileEnemy(Vector2 pos)
    {
       traps[Random.Range(0,traps.Count)].TileTrap(pos);
    }
    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            StartCoroutine(traps[Random.Range(0,traps.Count)].SpawnTrap()); //spawn trap
        }
    }
}
