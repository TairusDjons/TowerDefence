using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAI : MonoBehaviour
{

    public UnityEngine.GameObject target;
    public NavMeshAgent agent;


	void Start () {
        agent.SetDestination(target.transform.position);
	}

    public void Init(UnityEngine.GameObject target)
    {
        this.target = target;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
