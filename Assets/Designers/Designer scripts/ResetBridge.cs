using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBridge : MonoBehaviour {

    public GameObject bridge1;
    public GameObject bridge2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            bridge1.SetActive(true);
            bridge2.SetActive(true);
        }
    }
}
