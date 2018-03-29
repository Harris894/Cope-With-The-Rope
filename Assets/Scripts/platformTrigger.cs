using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class platformTrigger : MonoBehaviour {

    public UnityEvent OnActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            OnActivate.Invoke();
        }
    }
}
