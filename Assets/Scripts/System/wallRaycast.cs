using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRaycast : MonoBehaviour {

    public LayerMask hitLayer;
    //private Transform playerPos;
    public List<Transform> targets;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

            MeshRenderer wall;
            Vector3 dir = (transform.position - playerPos);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(playerPos, dir, 100f, hitLayer);
            Debug.DrawRay(playerPos, dir, Color.green);
            //Debug.Log(hits.Length);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hitObject = hits[i];
                //Debug.Log("Hit object: " + hitObject.transform.name);
                //hitObject.transform.gameObject.SetActive(false);
                wall = hitObject.transform.gameObject.GetComponent<MeshRenderer>();
                wall.enabled = false;
            }
        }
        


        

    }
}
