using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckingTest : MonoBehaviour {

    public GameObject otherCube;
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, otherCube.transform.position - transform.position, Color.green);
	}
}
