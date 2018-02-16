using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float time;
    public Vector3 cameraOffset;
    
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.position + cameraOffset, time);
	}
}
