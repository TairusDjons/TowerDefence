using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveUnit
{
    public GameObject prefabUnit;
    public Vector3 spawnPoint;
}

[System.Serializable]
public class UnitVector
{
    public List<WaveUnit> units;
    public int repeatCounter;
}