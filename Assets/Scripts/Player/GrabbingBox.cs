using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingBox : MonoBehaviour {

    public List<GameObject> objectsInTrigger = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        objectsInTrigger.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other) {
        objectsInTrigger.Remove(other.gameObject);
    }

    public bool HasPlayer() {
        foreach(GameObject go in objectsInTrigger) {
            if (go.GetComponent<PlayerController>()) {
                return true;
            }
        }
        return false;
    }

    public PlayerController GetPlayer() {
        foreach (GameObject go in objectsInTrigger) {
            if (go.GetComponent<PlayerController>()) {
                return go.GetComponent<PlayerController>();
            }
        }
        return null;
    }
}
