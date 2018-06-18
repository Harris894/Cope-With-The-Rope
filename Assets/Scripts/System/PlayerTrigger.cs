using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour {

    private List<ProPlayerController> playerList = new List<ProPlayerController>();
    public int amountOfPlayersToTrigger = 0; 
    public bool canOnlyBeTriggeredOnce;
    public UnityEvent OnTriggerEvent;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ProPlayerController>() != null && !playerList.Contains(other.GetComponent<ProPlayerController>()))
        {
            playerList.Add(other.GetComponent<ProPlayerController>());
        }

        if(canOnlyBeTriggeredOnce && triggered)
        {
            return;
        }
        else if( playerList.Count >= amountOfPlayersToTrigger)
        {
            triggered = true;
            OnTriggerEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ProPlayerController>() != null && !playerList.Contains(other.GetComponent<ProPlayerController>()))
        {
            playerList.Remove(other.GetComponent<ProPlayerController>());
        }
    }
}
