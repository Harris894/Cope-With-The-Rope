using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProUserInput : MonoBehaviour {

    public int playerNumber;

    ProPlayerController proPlayerController;

    //Inputs
    float moveForward, moveRight;
    float jump;

	// Use this for initialization
	void Start () {
        proPlayerController = GetComponent<ProPlayerController>();
	}
	
	// Update is called once per frame
	void Update () {


        //Reset values back to 0 so that it doesn't stack up.
        jump = 0;
        moveForward = 0;
        moveRight = 0;

        #region Keyboard
        jump += Input.GetAxis(string.Format("Primary Action{0}", playerNumber));
        moveForward += Input.GetAxis(string.Format("Vertical{0}", playerNumber));
        moveRight += Input.GetAxis(string.Format("Horizontal{0}", playerNumber));
        #endregion

        #region Joystick
        jump += Input.GetAxis(string.Format("A{0}", playerNumber));
        moveForward += Input.GetAxis(string.Format("Left Stick Y {0}", playerNumber));
        moveRight += Input.GetAxis(string.Format("Left Stick X {0}", playerNumber));
        #endregion

        //Limit all input between -1 and 1 since we are summing up all the values from different input methods.
        jump = Mathf.Clamp(jump, -1, 1);
        moveForward = Mathf.Clamp(moveForward, -1, 1);
        moveRight = Mathf.Clamp(moveRight, -1, 1);

        //Debug.Log(jump);
        //Debug.LogFormat("Forward: {0} + Right: {1}", moveForward, moveRight);
        //Debug.Log(Input.GetJoystickNames().Length);
        proPlayerController.SendInput(jump, moveForward, moveRight);
    }
}
