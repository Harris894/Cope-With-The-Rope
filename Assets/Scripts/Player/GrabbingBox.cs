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
        CheckForNullObjects();
        foreach(GameObject go in objectsInTrigger) {
            if (go != null && go.GetComponent<ProPlayerController>()) {
                return true;
            }
        }
        return false;
    }

    public void CheckForNullObjects()
    {
        List<GameObject> nullObjects = new List<GameObject>();
        foreach(GameObject go in objectsInTrigger)
        {
            if(go == null)
            {
                nullObjects.Add(go);
            }
        }
        foreach(GameObject go in nullObjects)
        {
            objectsInTrigger.Remove(go);
        }
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
