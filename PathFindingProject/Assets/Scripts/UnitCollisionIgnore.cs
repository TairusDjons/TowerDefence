using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCollisionIgnore : MonoBehaviour {

    // Use this for initialization

    public Collider objectToIgnore;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(objectToIgnore, collision.gameObject.GetComponent<Collider>());
        }
    }
}
