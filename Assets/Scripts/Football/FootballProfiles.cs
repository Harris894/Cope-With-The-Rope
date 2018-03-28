using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballProfiles : MonoBehaviour {

    public int score;
    public int teamID;

    List<PlayerController> playerControllers = new List<PlayerController>();
    

	// Use this for initialization
	void Awake () {
        Football.instance.teamList.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
