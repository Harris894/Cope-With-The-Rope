using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    public Camera mainCamera;
    public Camera insideCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            mainCamera.gameObject.SetActive(false);
            insideCamera.gameObject.SetActive(true);
        }
    }
}
