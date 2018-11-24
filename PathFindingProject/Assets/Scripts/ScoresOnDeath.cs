using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresOnDeath : MonoBehaviour {

    public Unit unit;
	// Use this for initialization
	void Start () {
        unit.Death += AddResource;
	}

    void AddResource()
    {
        TowerManager.instance.Resources += unit.value;
    }
}
