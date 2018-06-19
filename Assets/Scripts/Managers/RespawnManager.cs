using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RespawnManager : MonoBehaviour {

    public static RespawnManager instance;
    public List<Transform> respawnPoints = new List<Transform>();
    public List<ProPlayerController> playersInDeathZone = new List<ProPlayerController>();
    public float delay;

    private PuzzleProgressManager progressManager;
    private int amountOfPlayers;
    private ObiRope rope;

    [Header("Live data")]
    public Transform currentRespawnPoint;

    // Use this for initialization

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start () {
        progressManager = GetComponent<PuzzleProgressManager>();
        progressManager.onCheckPointReached += SpawnPositionCheck;
        FindPlayerControllers();
        
        SpawnPositionCheck();
    }

    

    public void SetPlayerOutOfBounds(ProPlayerController proPlayerController, bool inZone)
    {

        if (inZone){
            if (playersInDeathZone.Contains(proPlayerController))
                return;
            else
                playersInDeathZone.Add(proPlayerController);
        }
        else
        {
            playersInDeathZone.Remove(proPlayerController);
        }


        if(playersInDeathZone.Count >= amountOfPlayers){
            
            Respawn();
        }
    }

    [ContextMenu("Spawn")]
    public void SpawnPositionCheck()
    {
        Vector3 spawnPosition = respawnPoints[progressManager.GetProgressPointIndex()].transform.position;

        currentRespawnPoint = respawnPoints[progressManager.GetProgressPointIndex()].transform;

    }

    void FindPlayerControllers()
    {
        amountOfPlayers = 0;
        foreach (ProPlayerController proPlayerController in FindObjectsOfType<ProPlayerController>())
        {
            amountOfPlayers++;
        }
    }

    public void Respawn()
    {
        rope = playersInDeathZone[0].transform.parent.GetComponentInChildren<ObiRope>();
        if(rope != null)
        rope.gameObject.SetActive(false);

        List<ProPlayerController> templist = new List<ProPlayerController>();
        foreach(ProPlayerController player in playersInDeathZone)
        {
            templist.Add(player);
            player.GetComponent<ObiRigidbody>().kinematicForParticles = true;
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        StartCoroutine(DisableKinematic(delay,templist));
    }

    IEnumerator DisableKinematic(float delay, List<ProPlayerController> playerControllerList)
    {
        yield return new WaitForSeconds(delay);
        if(rope!= null)
        //rope.gameObject.SetActive(true);
        foreach (ProPlayerController player in playerControllerList)
        {
            player.transform.position = currentRespawnPoint.transform.position;
            player.GetComponent<ObiRigidbody>().kinematicForParticles = true;
            player.GetComponent<Rigidbody>().isKinematic = true;
        }

        rope.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        foreach (ProPlayerController player in playerControllerList)
        {
            player.GetComponent<ObiRigidbody>().kinematicForParticles = false;
            player.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
