using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPicker :  ITowerPlacer {

    [SerializeField]
    Tower currentTower;

    public bool deleteTower = false;
    public override Tower CurrentTower
    {
        get { return currentTower; }
        set { currentTower = value; }
    }

    public override void PickTower(Tower tower)
    {
        currentTower = tower;
        deleteTower = false;
    }

    public void SetDeleteTower()
    {
        deleteTower = !deleteTower;
    }
}
