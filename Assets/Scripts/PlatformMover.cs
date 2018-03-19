using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformMover : MonoBehaviour {

    public Transform movingPlatform;

    private Vector3 target = new Vector3(120, 260, 65);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
