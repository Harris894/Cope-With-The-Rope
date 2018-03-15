using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public List<Transform> targets;
    public float time;
    public Vector3 cameraOffset;
    
	// Update is called once per frame
	void Update () {
        Vector3 targetTransform = Vector3.zero;
        foreach(Transform target in targets){
            targetTransform += target.transform.position;
        }
        targetTransform = targetTransform / targets.Count;
        
        transform.position = Vector3.Lerp(transform.position, targetTransform + cameraOffset, time);
        transform.LookAt(targetTransform);
	}
}
