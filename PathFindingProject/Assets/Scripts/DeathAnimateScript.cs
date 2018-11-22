using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimateScript : MonoBehaviour
{

    public GameObject unit;
    // Use this for initialization
    void Start()
    {
        unit.GetComponent<IDestroyable>().Death += Animate;
    }

    void Animate()
    {
        unit.GetComponent<Rigidbody>().isKinematic = false;
        unit.GetComponent<Collider>().enabled = false;
        List<Rigidbody> rbs = new List<Rigidbody>(unit.GetComponentsInChildren<Rigidbody>());
        rbs.ForEach(rb => rb.isKinematic = false);
        List<Collider> cls = new List<Collider>(unit.GetComponentsInChildren<Collider>());
        cls.ForEach(cl => cl.enabled = false);
    }

}