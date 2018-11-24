using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITowerPlacer: MonoBehaviour{
    public abstract Tower CurrentTower { get; set; }
    public abstract void PickTower(Tower tower);
}
