using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Traps")]
public class ScriptableTrap : ScriptableObject
{
    //Scriptable objects
    public string nameOfTrap;
    public bool overTile; //can be on tile
}
