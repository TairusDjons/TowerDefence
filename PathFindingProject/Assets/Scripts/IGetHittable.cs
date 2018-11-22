using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GetHit();
public interface IGetHittable
{
    event GetHit GetHit;
}
