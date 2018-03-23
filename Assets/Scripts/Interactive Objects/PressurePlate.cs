using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public LayerMask triggerLayers;
    Vector3 offset = new Vector3(0, 0.2f, 0);

    [HideInInspector]
    public bool isPressed;
	
	void Update () {
        isPressed = Physics.CheckBox(transform.position + offset, transform.lossyScale * 0.5f,transform.rotation, triggerLayers) ? true : false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + offset, transform.lossyScale);
    }
}
