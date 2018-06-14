using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

    public RespawnManager respawnManager;

    private void Start()
    {
        respawnManager = RespawnManager.instance;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ProPlayerController>()!=null)
        {
            respawnManager.SetPlayerOutOfBounds(other.GetComponent<ProPlayerController>(), true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ProPlayerController>() != null)
        {
            respawnManager.SetPlayerOutOfBounds(other.GetComponent<ProPlayerController>(), false);
        }
    }

}
