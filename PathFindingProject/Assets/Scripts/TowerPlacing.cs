using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacing : MonoBehaviour
{
    public UnityEngine.GameObject tower;

    public Vector3 offset;

    bool towerSet = false;

	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseDown()
    {
        var tower = GameManager.instance.currentTower;
        if (!towerSet && tower != null)
        {
            tower = Instantiate(tower, this.transform.position + offset, Quaternion.identity);
            towerSet = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
