using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

    public List<Transform> respawnPoints = new List<Transform>();

    private PuzzleProgressManager progressManager;

    [Header("Live data")]
    public Transform currentRespawnPoint;

	// Use this for initialization
	void Start () {
        progressManager = GetComponent<PuzzleProgressManager>();

        progressManager.onCheckPointReached += SpawnPositionCheck;

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    [ContextMenu("Spawn")]
    public void SpawnPositionCheck()
    {
        Vector3 spawnPosition = respawnPoints[progressManager.GetProgressPointIndex()].transform.position;

        currentRespawnPoint = respawnPoints[progressManager.GetProgressPointIndex()].transform;

    }

    public void Respawn()
    {

    }
}
