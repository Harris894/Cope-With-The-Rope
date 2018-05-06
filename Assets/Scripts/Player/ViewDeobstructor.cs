using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDeobstructor : MonoBehaviour {

    public bool autoFindPlayersAtStartup = true;
    public LayerMask obstructionMask;
    public List<PlayerController> playerControllers = new List<PlayerController>();

    private List<List<ObstructionGroup>> hiddenObstructionGroups = new List<List<ObstructionGroup>>();

	// Use this for initialization
	void Start () {
        if (autoFindPlayersAtStartup)
        {
            foreach(PlayerController playerController in FindObjectsOfType<PlayerController>())
            {
                playerControllers.Add(playerController);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        int count = 0;
        foreach (PlayerController playerController in playerControllers)
        {
            Debug.DrawRay(transform.position, (playerControllers[count].transform.position - transform.position) * Vector3.Distance(transform.position, playerControllers[count].transform.position), Color.red);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, (playerControllers[count].transform.position - transform.position) * Vector3.Distance(transform.position, playerControllers[count].transform.position), 50f, obstructionMask);
            if(hits.Length > 0)
            {
                foreach(RaycastHit hit in hits)
                {
                    ObstructionGroup obstructionGroup = GetComponent<ObstructionGroup>();
                    if(obstructionGroup != null)
                    {

                    }
                }
            }
            count++;
        }

        
	}
}
