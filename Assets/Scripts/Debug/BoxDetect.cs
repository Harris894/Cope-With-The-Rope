using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetect : MonoBehaviour {

    public ParticleSystem fireworks;

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="BigBox")
        {
            fireworks.Play();
        }
    }
}
