using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition {
    public int tweenID;
    public Panel target;
    [SerializeField]
    public List<SubTransition> subTransition;
    public bool enableRaycastAfter;
    public bool setActiveAfter;
}
