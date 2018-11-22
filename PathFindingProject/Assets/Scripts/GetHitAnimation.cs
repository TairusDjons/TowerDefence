using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitAnimation : MonoBehaviour
{

    public GameObject unit;
    public float speed;
    public float amount;

    bool canShake = false;
    void Shake()
    {
       StartCoroutine(ShakeDelay());
    }

    IEnumerator ShakeDelay()
    {
        canShake = true;
        yield return new WaitForSeconds(0.6f);
        canShake = false;
    }
    void Start () {
        unit.GetComponent<IGetHittable>().GetHit += Shake;
	}
	
	// Update is called once per frame
	void Update () {
        if (canShake)
        {
            Vector3 offset = new Vector3((Mathf.Sin(Time.time * speed) * amount), 0, (Mathf.Sin(Time.time * speed) * amount));
            transform.position = Vector3.MoveTowards(transform.position, transform.position + offset, Time.deltaTime);
        }
    }
}
