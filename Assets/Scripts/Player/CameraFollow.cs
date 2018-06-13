using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {

    public List<Transform> targets;
    public float time;
    public Vector3 cameraOffset;
    
	// Update is called once per frame
	void Update () {
        if(targets.Count > 0) {
            Vector3 targetTransform = Vector3.zero;
            Quaternion targetRotation=Quaternion.identity;
            foreach (Transform target in targets) {
                if(target != null)
                targetTransform += target.transform.position;
                targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            }
            targetTransform = targetTransform / targets.Count;
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, time * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetTransform + cameraOffset, time * Time.deltaTime);
            transform.LookAt(targetTransform);
        }
	}
}
