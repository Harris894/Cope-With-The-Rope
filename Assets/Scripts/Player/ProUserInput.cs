using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProUserInput : MonoBehaviour {

    public int playerNumber;
    public bool useJoystick;

    ProPlayerController proPlayerController;

    //Inputs
    float moveFoward, MoveRight;
    float jump;

	// Use this for initialization
	void Start () {
        proPlayerController = GetComponent<ProPlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!useJoystick) {
            #region Keyboard
            //jump = Input.GetAxis()
            jump = Input.GetAxis(string.Format("Primary Action{0}", playerNumber));
            moveFoward = Input.GetAxis(string.Format("Vertical{0}", playerNumber));
            MoveRight = Input.GetAxis(string.Format("Horizontal{0}", playerNumber));
            #endregion
        }
        else {
            #region Joystick
            jump = Input.GetAxis(string.Format("A{0}", playerNumber));
            moveFoward = Input.GetAxis(string.Format("Left Stick Y {0}", playerNumber));
            MoveRight = Input.GetAxis(string.Format("Left Stick X {0}", playerNumber));
            #endregion
        }

        //Debug.Log(jump);
        //Debug.Log(moveFoward);
        //Debug.Log(Input.GetJoystickNames().Length);
        proPlayerController.SendInput(jump, moveFoward, MoveRight);
    }
}
