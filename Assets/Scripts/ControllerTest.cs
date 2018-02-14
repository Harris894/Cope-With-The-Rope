using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fire2");
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Horizontal");
        }

        if(Input.GetAxis("Left Stick 1") != 0) {
            Debug.Log("Left Stick value : " + Input.GetAxis("Left Stick 1"));
        }

        if (Input.GetAxis("Right Stick 1") != 0) {
            Debug.Log("Right Stick value : " + Input.GetAxis("Right Stick 1"));
        }
    }
}
