using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour {

    public static ProgressionManager instance;

    public int progressIndex = 0;

    public List<ProgressionObject> progressionObjectList = new List<ProgressionObject>();

    public delegate void AddProgressPoint();
    public AddProgressPoint OnAddProgressPoint;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
        OnAddProgressPoint += CheckProgressionList;
    }

    public void AddProgressPointValue(int value = 1) {
        progressIndex += value;

        if(OnAddProgressPoint != null) {
            OnAddProgressPoint();
        }
    }

    void CheckProgressionList() {
        for(int i = 0; i < progressionObjectList.Count; i++) {
            if (progressIndex -1 >= i) {
                progressionObjectList[i].Activate();
            }
        }
    }

}

[System.Serializable]
public class ProgressionObject {
    public string GameObjectName;
    public GameObject doorPiece;
    public GameObject light;

    public void Activate() {
        if(doorPiece != null)
        doorPiece.SetActive(false);

        if (light != null)
        light.SetActive(true);
    }
}
