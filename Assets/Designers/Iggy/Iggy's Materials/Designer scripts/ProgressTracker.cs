using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour {

    public static List<GameObject>[] porticullises;
    //public List<GameObject>[] BlueLights;

    //public GameObject BlueLight1;
    //public GameObject BlueLight2;
    //public GameObject BlueLight3;
    //public GameObject BlueLight4;

    public static GameObject FoKapcsolo;
    public static int counter = 0;
    //public GameObject RunePlate;

    void Start () {
        DontDestroyOnLoad(FoKapcsolo);
	}

    //private void WhenLevelLoaded ()
    //{
        
    //}

    void OnPressureplatePressed () {
		
	}
}
