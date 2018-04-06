using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour {

    public Animator animator;
    public string animationName;
    public bool state;

	public void PlayAnimation()
    {
        Debug.Log(animationName + state);
        animator.SetBool(animationName, state);
    }
}
