using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Unit : MonoBehaviour, IDestroyable, IGetHittable
{
    [SerializeField]
    int health;

    public event OnDeath Death;
    public event GetHit GetHit;
    public int Health
    {
        get { return health; }
        set
        {
            GetHit();
            if (value <= 0)
            {
                Death();
                Destroy(this.gameObject);
            }
            else
                health = value;
        }
    }
    public int damage;
  
    public float hitDelay;

    bool isDelay = false;
  
    IEnumerator Delay()
    {
        isDelay = true;
        yield return new WaitForSeconds(hitDelay);
        isDelay = false;
    }

    private void OnTriggerStay(Collider other)
    {
        var castle = other.gameObject.GetComponent<Castle>();
        if (castle && !isDelay)
        {
            castle.Health -= damage;
            StartCoroutine("Delay");
        }
    }
   
}
