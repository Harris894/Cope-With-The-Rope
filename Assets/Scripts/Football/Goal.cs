using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public int teamID;
    public string ballTag;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(ballTag)) {
            Football.instance.GoalScored(teamID, other.GetComponent<Ball>().goalValue);
        }
    }

    [ContextMenu("Fake goal -1")]
    public void FakeGoal() {
        Football.instance.GoalScored(teamID, -1);
    }
}
