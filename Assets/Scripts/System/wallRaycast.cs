using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRaycast : MonoBehaviour {

    public LayerMask hitLayer;
    //private Transform playerPos;
    public List<Transform> targets;

    public List<GameObject> hitList = new List<GameObject>();
    public List<GameObject> lastHitList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        //Calculate center of the player positions
        if (targets.Count>0)
        {
            Vector3 playerPos = Vector3.zero;
            foreach (Transform target in targets)
            {
                if (target != null)
                {
                    playerPos += target.transform.position;
                }
            }
            playerPos = playerPos / targets.Count;


            //Create copy of old list
            if(hitList.Count > 0) {
                lastHitList = new List<GameObject>(hitList);
            }



            //Prepare The raycastall
            MeshRenderer wall;
            Vector3 dir = (transform.position - playerPos);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(playerPos, dir, 100f, hitLayer);
            Debug.DrawRay(playerPos, dir, Color.green);
            hitList.Clear();
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hitObject = hits[i];
                hitList.Add(hitObject.transform.gameObject);
                //Debug.Log("Hit object: " + hitObject.transform.name);
                //hitObject.transform.gameObject.SetActive(false);
                wall = hitObject.transform.gameObject.GetComponent<MeshRenderer>();
                wall.enabled = false;
            }


            //Compare the 2 list for differences
            foreach(GameObject go in hitList) {
                if (lastHitList.Contains(go)) {
                    lastHitList.Remove(go);
                }
            }

            //Make Walls visible again
            foreach(GameObject go in lastHitList) {
                wall = go.GetComponent<MeshRenderer>();
                wall.enabled = true;
            }
        }
        


        

    }
}
