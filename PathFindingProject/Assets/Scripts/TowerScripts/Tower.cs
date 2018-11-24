using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public IBullet bullet;
    public Transform tower;
    public Transform shootPosition;
    public float fireRate;
    public float rotationSpeed;

    public string shootTag;
    public int value;
    private GameObject currentTarget;

    private bool canShoot = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTarget != null)
        {
            Rotate();
            if (canShoot)
                Shoot();
        }
	}


    private void Rotate()
    {
        Vector3 direction = (currentTarget.transform.position - tower.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        tower.transform.rotation = Quaternion.Slerp(tower.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }
    private void Shoot()
    {
        IBullet blt = Instantiate(bullet, shootPosition.position, tower.transform.rotation);
        blt.Target = currentTarget.transform;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentTarget)
            currentTarget = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(shootTag) && currentTarget == null)
        {
            currentTarget = other.gameObject;
        }
    }
   
   
}
