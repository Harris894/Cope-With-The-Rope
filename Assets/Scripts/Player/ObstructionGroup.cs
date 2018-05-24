using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionGroup : MonoBehaviour {

    public List<GameObject> obstructionObjects = new List<GameObject>();
    public bool isObstructing = false;

    public void Update()
    {
        if(!isObstructing && !gameObject.activeSelf)
        {
            foreach(GameObject go in obstructionObjects)
            {
                go.SetActive(true);
            }
        }
    }

}
