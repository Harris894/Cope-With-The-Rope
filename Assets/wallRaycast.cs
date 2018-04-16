using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRaycast : MonoBehaviour {

    public LayerMask hitLayer;
    public Transform playerPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer wall;
        Vector3 dir = (transform.position-playerPos.transform.position);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(playerPos.position, dir, 100f,hitLayer);
        Debug.DrawRay(playerPos.position, dir, Color.green);
        Debug.Log(hits.Length);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hitObject = hits[i];
            Debug.Log("Hit object: " + hitObject.transform.name);
            //hitObject.transform.gameObject.SetActive(false);
            wall=hitObject.transform.gameObject.GetComponent<MeshRenderer>();
            wall.enabled = false;
        }

    }
}
