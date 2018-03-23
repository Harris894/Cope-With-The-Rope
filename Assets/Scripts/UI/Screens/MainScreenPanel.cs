using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenPanel : Panel {

    private void Start() {

    }

    public override void OnEnter() {
        //Debug.Log("Start");
    }

    public override void OnUpdate() {
        //Debug.Log("Update");
    }

    public override void OnExit() {
        throw new NotImplementedException();
    }

}
