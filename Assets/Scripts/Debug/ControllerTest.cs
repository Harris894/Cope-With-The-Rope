using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        #region Controller 1
        if(Input.GetAxis("Left Stick X 1") != 0) {
            Debug.Log("Left Stick X value : " + Input.GetAxis("Left Stick X 1"));
        }

        if (Input.GetAxis("Left Stick Y 1") != 0)
        {
            Debug.Log("Left Stick Y value : " + Input.GetAxis("Left Stick Y 1"));
        }

        if (Input.GetAxis("Right Stick X 1") != 0) {
            Debug.Log("Right Stick X value : " + Input.GetAxis("Right Stick X 1"));
        }

        if (Input.GetAxis("Right Stick Y 1") != 0)
        {
            Debug.Log("Right Stick Y value : " + Input.GetAxis("Right Stick Y 1"));
        }

        if (Input.GetAxis("Dpad X 1") != 0)
        {
            Debug.Log("Dpad X value : " + Input.GetAxis("Dpad X 1"));
        }

        if (Input.GetAxis("Dpad Y 1") != 0)
        {
            Debug.Log("Dpad Y value : " + Input.GetAxis("Dpad Y 1"));
        }

        if (Input.GetButtonDown("A1"))
        {
            Debug.Log("A1");
        }

        if (Input.GetButtonDown("B1"))
        {
            Debug.Log("B1");
        }

        if (Input.GetButtonDown("X1"))
        {
            Debug.Log("X1");
        }

        if (Input.GetButtonDown("Y1"))
        {
            Debug.Log("Y1");
        }

        if (Input.GetButtonDown("Left Stick Click 1"))
        {
            Debug.Log("Left Stick Click 1");
        }

        if (Input.GetButtonDown("Right Stick Click 1"))
        {
            Debug.Log("Right Stick Click 1");
        }

        if (Input.GetButtonDown("Start 1"))
        {
            Debug.Log("Start 1");
        }

        if (Input.GetButtonDown("Select 1"))
        {
            Debug.Log("Select 1");
        }

        if (Input.GetButtonDown("Right Bumper 1"))
        {
            Debug.Log("Right Bumper 1");
        }

        if (Input.GetButtonDown("Left Bumper 1"))
        {
            Debug.Log("Left Bumper 1");
        }

        if (Input.GetAxis("Triggers 1") != 0)
        {
            Debug.Log("Triggers 1 : " + Input.GetAxis("Triggers 1"));
        }
        #endregion

        #region Controller 2
        if (Input.GetAxis("Left Stick X 2") != 0)
        {
            Debug.Log("Left Stick X value : " + Input.GetAxis("Left Stick X 2"));
        }

        if (Input.GetAxis("Left Stick Y 2") != 0)
        {
            Debug.Log("Left Stick Y value : " + Input.GetAxis("Left Stick Y 2"));
        }

        if (Input.GetAxis("Right Stick X 2") != 0)
        {
            Debug.Log("Right Stick X value : " + Input.GetAxis("Right Stick X 2"));
        }

        if (Input.GetAxis("Right Stick Y 2") != 0)
        {
            Debug.Log("Right Stick Y value : " + Input.GetAxis("Right Stick Y 2"));
        }

        if (Input.GetButtonDown("A2"))
        {
            Debug.Log("A2");
        }

        if (Input.GetButtonDown("B2"))
        {
            Debug.Log("B2");
        }

        if (Input.GetButtonDown("X2"))
        {
            Debug.Log("X2");
        }

        if (Input.GetButtonDown("Y2"))
        {
            Debug.Log("Y2");
        }

        if (Input.GetButtonDown("Left Stick Click 2"))
        {
            Debug.Log("Left Stick Click 2");
        }

        if (Input.GetButtonDown("Right Stick Click 2"))
        {
            Debug.Log("Right Stick Click 2");
        }

        if (Input.GetButtonDown("Start 2"))
        {
            Debug.Log("Start 2");
        }

        if (Input.GetButtonDown("Select 2"))
        {
            Debug.Log("Select 2");
        }

        if (Input.GetButtonDown("Right Bumper 2"))
        {
            Debug.Log("Right Bumper 2");
        }

        if (Input.GetButtonDown("Left Bumper 2"))
        {
            Debug.Log("Left Bumper 2");
        }

        if (Input.GetAxis("Triggers 2") != 0)
        {
            Debug.Log("Triggers 2 : " + Input.GetAxis("Triggers 2"));
        }
#endregion
    }
}
