using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDeath();
public interface IDestroyable
{
    event OnDeath Death;
}
