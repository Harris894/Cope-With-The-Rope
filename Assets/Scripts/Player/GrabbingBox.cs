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
            if (go.GetComponent<ProPlayerController>()) {
                return true;
            }
        }
        return false;
    }

    public ProPlayerController GetPlayer() {
        foreach (GameObject go in objectsInTrigger) {
            if (go.GetComponent<ProPlayerController>()) {
                return go.GetComponent<ProPlayerController>();
            }
        }
        return null;
    }
}
