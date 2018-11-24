using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacing : MonoBehaviour
{
    public Tower tower;

    public Vector3 offset;

    public bool towerSet { get { return tower != null; } }

    public Vector3 Position()
    {
        return transform.position + offset;
    }

	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseDown()
    {
        TowerManager.instance.SetPlace(this);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
