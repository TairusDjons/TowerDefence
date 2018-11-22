using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraPoint
{
    [SerializeField]
    Quaternion point;

    [SerializeField]
    CameraPoint right;

    [SerializeField]
    CameraPoint left;
    public Quaternion Point { get { return point; } }
    public CameraPoint Right{ get { return right; } }
    public CameraPoint Left { get { return left; } }

    public CameraPoint(Quaternion point, CameraPoint left, CameraPoint right)
    {
        this.point = point;
        this.left = left;
        this.right = right;
    }

}
