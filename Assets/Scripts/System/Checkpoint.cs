using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Transform spawnPosition;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Reached checkpoint");
        CheckpointManager.instance.ReachedCheckpoint(this); 
    }
}
