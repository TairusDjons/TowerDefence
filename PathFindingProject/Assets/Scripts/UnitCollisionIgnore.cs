using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCollisionIgnore : MonoBehaviour {

    // Use this for initialization

    public string IgnoreLayer;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(IgnoreLayer))
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }
}
