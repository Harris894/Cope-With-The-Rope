using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showScore : MonoBehaviour {

    public Text blueScore;
    public Text redScore;
    float red;
    float blue;

	// Use this for initialization
	void Start () {
        red = PlayerPrefs.GetFloat("RedScore");
        blue = PlayerPrefs.GetFloat("BlueScore");
	}
	
	// Update is called once per frame
	void Update () {


        blueScore.text = "" + blue;
        redScore.text = "" + red;

	}
}
