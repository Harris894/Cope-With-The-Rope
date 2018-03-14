using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePlayerConnect : MonoBehaviour {

    public GameObject ropePart;
    public GameObject otherPlayer;
    public LayerMask playerLayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,otherPlayer.transform.position,out hit, 100f, playerLayer))
        {
            Debug.Log(hit.transform.gameObject.name);
        }

        Debug.DrawLine(transform.position, otherPlayer.transform.position, Color.red);
	}
}
