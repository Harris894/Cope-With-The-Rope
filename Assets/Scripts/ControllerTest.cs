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
    }
}
