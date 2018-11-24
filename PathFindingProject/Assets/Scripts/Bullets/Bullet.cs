using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet {

    public override void DealDamage(GameObject unit)
    {
        unit.GetComponent<HasHealth>().Health -= Damage;
    }

    public override void Move()
    {
        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * Speed);
            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Speed);
        }
    }

  
	// Update is called once per frame
	void Update () {
        if (Target == null)
            Destroy(this.gameObject, 0.3f);
        Move();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == Target)
        {
            DealDamage(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
