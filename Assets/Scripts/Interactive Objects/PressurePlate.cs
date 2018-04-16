using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public LayerMask triggerLayers;
    Vector3 offset = new Vector3(0, 0.2f, 0);
    public Collider collider;
    public bool showGizmo = false;

    [HideInInspector]
    public bool isPressed;

    private void Start() {
        collider = GetComponent<Collider>();
    }

    void Update () {
        isPressed = Physics.CheckBox(collider.bounds.center + offset, new Vector3(collider.bounds.size.x, 1, collider.bounds.size.z), transform.rotation, triggerLayers) ? true : false;
        //isPressed = Physics.CheckBox(transform.position + offset, transform.lossyScale * 0.5f,transform.rotation, triggerLayers) ? true : false;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(transform.position + offset, transform.lossyScale);
        if(collider != null && showGizmo)
        Gizmos.DrawCube(collider.bounds.center + offset, new Vector3(collider.bounds.size.x, 1, collider.bounds.size.z));
    }
}
