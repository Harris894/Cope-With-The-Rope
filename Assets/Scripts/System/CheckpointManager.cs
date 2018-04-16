using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public static CheckpointManager instance;

    public List<Checkpoint> checkpointList = new List<Checkpoint>();
    public Checkpoint activeCheckpoint;

    private void Awake() {
        instance = this; 
    }

    public void ReachedCheckpoint(Checkpoint checkpoint) {
        int currentCheckpointIndex = -2;
        int newCheckpointIndex = -2;
        for(int i = 0; i < checkpointList.Count; i++) {
            //If its the same checkpoint as the active one
            if(activeCheckpoint == checkpointList[i]) {
                currentCheckpointIndex = i;
            }

            //If its the same checkpoint as the new one
            if (checkpoint == checkpointList[i]) {
                newCheckpointIndex = i;
            }
        }

        if(newCheckpointIndex > currentCheckpointIndex) {
            SetNewCheckpoint(checkpoint);
        }
    }

    public void SetNewCheckpoint(Checkpoint checkpoint) {
        activeCheckpoint = checkpoint;
    }

    public Vector3 GetSpawnLocation() {
        return activeCheckpoint.spawnPosition.position;
    }
}
