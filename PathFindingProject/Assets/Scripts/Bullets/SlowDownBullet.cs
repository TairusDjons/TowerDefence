using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownBullet : IBullet {
    
    public float slowDownEffect;
    public float slowDownTime;
  
    public override void DealDamage(GameObject unit)
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.GetComponent<ParticleSystem>().Stop();
        unit.GetComponent<HasHealth>().Health -= Damage;
        if (unit == null)
            Destroy(this.gameObject);
        StartCoroutine(SlowDown(unit.GetComponent<UnitAI>()));
    }

    IEnumerator SlowDown(UnitAI ai)
    {
        try
        {
            ai.agent.speed /= slowDownEffect;
            yield return new WaitForSeconds(slowDownTime);
            if (ai != null)
            ai.agent.speed *= slowDownEffect;
        }
        finally {
            Destroy(this.gameObject);
        }
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
    void Update()
    {
        if (Target == null)
            Destroy(this.gameObject, 0.5f);
        Move();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == Target)
        {
            DealDamage(other.gameObject);
        }
    }

    // Update is called once per frame
   
}
