using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionInvoker : MonoBehaviour {

    public UnityEvent action;
    //public Animator otherAnim;
    //private Animator anim;


    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
	}


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ProPlayerController>() != null)
        {
            Activate();
        }
    }

    void Activate()
    {
        action.Invoke();
    }
}
