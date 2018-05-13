using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDeobstructor2 : MonoBehaviour
{

    public bool autoFindPlayersAtStartup = true;
    public LayerMask obstructionMask;
    public List<PlayerController> playerControllers = new List<PlayerController>();
    public List<ObstructionGroup> obstructionGroups = new List<ObstructionGroup>();

    // Use this for initialization
    void Start()
    {
        if (autoFindPlayersAtStartup)
        {
            foreach (PlayerController playerController in FindObjectsOfType<PlayerController>())
            {
                playerControllers.Add(playerController);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        ResetIsObstructingTest();
        int count = 0;
        foreach (PlayerController playerController in playerControllers)
        {
            Debug.DrawRay(transform.position, (playerControllers[count].transform.position - transform.position) * Vector3.Distance(transform.position, playerControllers[count].transform.position), Color.red);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, (playerControllers[count].transform.position - transform.position) * Vector3.Distance(transform.position, playerControllers[count].transform.position), 50f, obstructionMask);
            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    ObstructionGroup obstructionGroup = hit.transform.GetComponent<ObstructionGroup>();
                    if (obstructionGroup == null)
                    {
                        //Single handling
                    }
                    else
                    {
                        if (!obstructionGroups.Contains(obstructionGroup))
                        {
                            obstructionGroups.Add(obstructionGroup);
                        }
                        obstructionGroup.isObstructing = true;
                        print(obstructionGroup.isObstructing);
                    }

                }
            }
            count++;
        }

        UpdateVisuals();
    }

    private void ResetIsObstructingTest()
    {
       foreach(ObstructionGroup obstructionGroup in obstructionGroups)
        {
            obstructionGroup.isObstructing = false;
        }
    }

    private void UpdateVisuals()
    {
        List<ObstructionGroup> temp = new List<ObstructionGroup>(obstructionGroups);
        print(temp.Count);
        foreach (ObstructionGroup obstructionGroup in temp)
        {
            if(obstructionGroup.isObstructing == false)
            {
                foreach(GameObject go in obstructionGroup.obstructionObjects)
                {
                    go.SetActive(true);
                }
                obstructionGroups.Remove(obstructionGroup);
            }
            else
            {
                foreach (GameObject go in obstructionGroup.obstructionObjects)
                {
                    go.SetActive(false);
                }
            }
        }
    }
}
