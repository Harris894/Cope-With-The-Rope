using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    /// <summary>
    /// This dictionary links the player controllers with their respective input number.
    /// </summary>
    public Dictionary<PlayerController, int> controllerList = new Dictionary<PlayerController, int>();
    public List<PlayerController> playerControllers;
    int connectedControllerCount = 0;

    // Use this for initialization
    void Start () {
        if(playerControllers.Count < 1)
        {
            FindPlayerControllers();
        }
        else
        {
            foreach (PlayerController playerController in playerControllers)
            {
                controllerList.Add(playerController, 0);
            }
        }
        CheckConnectedControllers();
        AssignInput();
	}

    /// <summary>
    /// Gets all the PlayerControllers it can find in the scene.
    /// </summary>
    void FindPlayerControllers()
    {
        PlayerController[] allPlayerControllers = FindObjectsOfType<PlayerController>();
        Debug.Log(allPlayerControllers.Length + " Player Controllers found!");
        foreach(PlayerController playerController in allPlayerControllers)
        {
            controllerList.Add(playerController, 0);
        }
    }

    /// <summary>
    /// Checks for the amount of connected controllers.
    /// also makes sure to check if the name of the controller is not empty.
    /// Appears to be a bug in which there is a "ghost controller" connected.
    /// </summary>
    void CheckConnectedControllers()
    {
        foreach (string joystickName in Input.GetJoystickNames())
        {
            if (joystickName.Length > 0)
                connectedControllerCount++;

            Debug.Log(joystickName);
        }
        print(connectedControllerCount);
    }

    /// <summary>
    /// Goes over the input devices and checks if there are still unused controllers.
    /// If that is not the case it will assign keyboard inputs.
    /// TODO: set the value for the dictionary.
    /// </summary>
    void AssignInput()
    {
        int assignedControllerCount = 0;
        int assignedKeyboardCount = 0;
        foreach(PlayerController entry in controllerList.Keys)
        {
            Debug.Log("HI");
            if(assignedControllerCount < connectedControllerCount)
            {
                entry.controllerNumber = assignedControllerCount + 1;
                assignedControllerCount++;
                entry.useController = true;
                Debug.Log("Assing Controller");
            }
            else if(assignedKeyboardCount < 2)
            {
                entry.controllerNumber = assignedKeyboardCount + 1;
                assignedKeyboardCount++;
                entry.useController = false;
                Debug.Log("Assing Keyboard");
            }
            else
            {
                Debug.LogError(string.Format("Couldn't assign unique input device to PlayerController of object {0}", entry.gameObject.name));
            }
            //controllerList[entry] = entry.controllerNumber;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DetectControllerInput()
    {
        for(int i = connectedControllerCount; i < 5; i++)
        {
            if(Input.GetAxis(string.Format("Left Stick X {0}", i)) != 0){

            }
            else if(Input.GetAxis(string.Format("Left Stick Y {0}", i)) != 0)
            {

            }
            else if (Input.GetAxis(string.Format("Right Stick X {0}", i)) != 0)
            {

            }
            else if (Input.GetAxis(string.Format("Right Stick Y {0}", i)) != 0)
            {

            }
            else if (Input.GetButtonDown(string.Format("X{0}",i))){

            }
            else if (Input.GetButtonDown(string.Format("Y{0}", i)))
            {

            }
            else if (Input.GetButtonDown(string.Format("B{0}", i)))
            {

            }
            else if (Input.GetButtonDown(string.Format("A{0}", i)))
            {

            }

        }
    }
}
