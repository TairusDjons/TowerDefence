using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Castle : MonoBehaviour, IDestroyable, IGetHittable, HasHealth
{
    [SerializeField]
    int health;
    public int Health
    {
        get { return health; }
        set
        {
            GetHit();
            if (value <= 0)
            {
                Death();
                Destroy(this.gameObject, 3);
            }
            else
                health = value;
        }
    }
    public event OnDeath Death;
    public event GetHit GetHit;

  

	// Update is called once per frame
}