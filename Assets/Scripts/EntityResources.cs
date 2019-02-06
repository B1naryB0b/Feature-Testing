using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityResources
{
    public GameObject entity;
    [Range(0, 1)]
    public float water;
    public float energy;
    public float atmosphere;
    public bool destructible;

    public bool[] selections = new bool[4];

}
