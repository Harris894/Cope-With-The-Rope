using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingBridges : MonoBehaviour {

    public List<ProPlayerController> playersOnBrigde = new List<ProPlayerController>();
    public GameObject destructibleBridge;

    private int amountOfPlayers;
    

    private void Start()
    {
        FindPlayerControllers();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ProPlayerController>() != null)
        {
            SetPlayerOutOfBounds(other.GetComponent<ProPlayerController>(), true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ProPlayerController>() != null)
        {
            SetPlayerOutOfBounds(other.GetComponent<ProPlayerController>(), false);
        }
    }

    void FindPlayerControllers()
    {
        amountOfPlayers = 0;
        foreach (ProPlayerController proPlayerController in FindObjectsOfType<ProPlayerController>())
        {
            amountOfPlayers++;
        }
    }

    private void SetPlayerOutOfBounds(ProPlayerController proPlayerController, bool inZone)
    {
        if (inZone)
        {
            if (playersOnBrigde.Contains(proPlayerController))
                return;
            else
                playersOnBrigde.Add(proPlayerController);
        }
        else
        {
            playersOnBrigde.Remove(proPlayerController);
        }


        if (playersOnBrigde.Count >= amountOfPlayers)
        {
            Debug.Log("2 in zone");
            Destruct();
        }
    }

    private void Destruct()
    {
        Instantiate(destructibleBridge, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
