using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDeobstructor : MonoBehaviour {

    public bool autoFindPlayersAtStartup = true;
    public LayerMask obstructionMask;
    public List<PlayerController> playerControllers = new List<PlayerController>();


    private Dictionary<List<GameObject>, bool> hiddenObstructionGroupsDictionary = new Dictionary<List<GameObject>, bool>();


    private List<List<GameObject>> tempKeyList = new List<List<GameObject>>();

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

        tempKeyList.Clear();
        foreach (List<GameObject> goList in hiddenObstructionGroupsDictionary.Keys)
        {
            tempKeyList.Add(goList);
        }

        foreach (List<GameObject> value in hiddenObstructionGroupsDictionary.Keys)
        {
            tempKeyList.Add(value);
        }

        //Reset dictionary
        foreach(List<GameObject> value in tempKeyList)
        {
            hiddenObstructionGroupsDictionary[value] = false;
        }

        foreach (PlayerController playerController in playerControllers)
        {
            Debug.DrawRay(transform.position, (playerControllers[count].transform.position - transform.position) * Vector3.Distance(transform.position, playerControllers[count].transform.position), Color.red);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, (playerControllers[count].transform.position - transform.position) * Vector3.Distance(transform.position, playerControllers[count].transform.position), 50f, obstructionMask);
            if(hits.Length > 0)
            {
                foreach(RaycastHit hit in hits)
                {
                    ObstructionGroup obstructionGroup = hit.transform.GetComponent<ObstructionGroup>();
                    if(obstructionGroup == null)
                    {
                        //do single handling
                        Debug.Log("Single handling");
                    }
                    else
                    {
                        if (hiddenObstructionGroupsDictionary.ContainsKey(obstructionGroup.obstructionObjects)){
                            hiddenObstructionGroupsDictionary[obstructionGroup.obstructionObjects] = true;
                        }
                        else
                        {
                            Debug.Log("Add to dict");
                            hiddenObstructionGroupsDictionary.Add(obstructionGroup.obstructionObjects, true);
                        }
                        //hiddenObstructionGroups.Add(obstructionGroup.obstructionObjects);
                        //hiddenObstructionGroupsDictionary.Add(obstructionGroup.obstructionObjects, true);
                    }
                    Debug.Log("Length " + hits.Length);
                }
            }
            count++;

        }
        VisualUpdate();
	}

    void VisualUpdate()
    {
        //CopyKeysToList(tempKeyList, hiddenObstructionGroupsDictionary.Keys);
        tempKeyList.Clear();
        foreach(List<GameObject> goList in hiddenObstructionGroupsDictionary.Keys)
        {
            tempKeyList.Add(goList);
        }

        foreach (List<GameObject> key in tempKeyList)
        {
            if (hiddenObstructionGroupsDictionary[key])
            {
                foreach(GameObject go in key)
                {
                    go.SetActive(false);
                    Debug.Log("enable");
                }
            }
            else
            {
                foreach(GameObject go in key)
                {

                    go.SetActive(true);
                    hiddenObstructionGroupsDictionary.Remove(key);
                    Debug.Log("disable");
                }
            }
        }
    }

    void CopyKeysToList(List<List<GameObject>> list, KeyValuePair<List<List<GameObject>>,bool> keypair)
    {
        list.Clear();
        //    foreach (List<GameObject> key in keypair)
        //    {
        //        list.Add(key);
        //    }
    }


}
