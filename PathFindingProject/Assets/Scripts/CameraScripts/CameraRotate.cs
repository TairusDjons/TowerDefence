using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    public Vector3 rotateDegree;
    public float speed;

    Quaternion start;
	void Start () {
        start = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(-rotateDegree));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(rotateDegree));
        }
    }

    IEnumerator Rotate(Vector3 rotateDegree)
    {
        start.eulerAngles += rotateDegree;
        while (transform.rotation != start)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, start, Time.deltaTime * speed);
            yield return 0;
        }
    }
}
