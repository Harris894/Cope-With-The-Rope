using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorProgression : MonoBehaviour {

 
    public void DoorTriggered()
    {
        ProgressionManager.instance.AddProgressPointValue();
    }


}
