using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBullet: MonoBehaviour {

    [SerializeField]
    int damage;

    [SerializeField]
    float speed;

    Transform target;
    public int Damage { get { return damage; } set { damage = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public Transform Target { get { return target; } set { target = value; } }
    public abstract void Move();
    public abstract void DealDamage(GameObject unit);
}
