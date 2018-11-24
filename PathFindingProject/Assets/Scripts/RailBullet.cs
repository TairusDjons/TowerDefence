using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailBullet : IBullet
{

    bool shoot = true;
    public override void Move()
    {
        if (Target != null)
        {
            transform.LookAt(Target);
            Vector3 centerPos = (transform.position + Target.position) / 2f;
            transform.position = centerPos;
            Vector3 direction = Target.position - transform.position;
            direction = Vector3.Normalize(direction);
            transform.forward = direction;
            Vector3 scale = new Vector3(0.3f, 0.3f, 1f);
            scale.z = Vector3.Distance(transform.position, Target.position);
            transform.localScale = scale * 2f;
           //ransform.localScale.Set(transform.localScale.x, transform.localScale.y, 0 + Mathf.Abs((Target.transform.position - transform.position).z));
             StartCoroutine(DestroyAfter());
        }
    }
    public override void DealDamage(GameObject unit)
    {
        unit.GetComponent<Unit>().Health -= Damage;
    }

    IEnumerator DestroyAfter()
    {
        Quaternion newRotation = transform.rotation;
        newRotation.eulerAngles += new Vector3(0, 0, 180);
        while (transform.rotation != newRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * Speed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0,0,transform.localScale.z), Time.deltaTime * Speed*2);
            yield return 0;
        }
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == Target)
        {
            DealDamage(other.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Target != null && shoot)
        {
            Move();
            shoot = false;
        }
	}
}
