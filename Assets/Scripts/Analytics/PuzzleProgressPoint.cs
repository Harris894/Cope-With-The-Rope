using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine;
using GameAnalyticsSDK;

public class PuzzleProgressPoint : MonoBehaviour {

    public string puzzleName;
    public string playerTag = "Player";
    private float startTime;
    private float endTime;
    private bool pointPassed = false;
    public int timesGrabbed;



    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(playerTag)) {
            PuzzleProgressManager.instance.PointReached(this);
            startTime = Time.time;
        } 
    }

    public void EnterPoint() {
        PuzzleProgressManager.instance.PointReached(this);
        startTime = Time.time;
    }

    [ContextMenu("Send data")]
    public void ExitPoint() {
        if (!pointPassed) {
            pointPassed = true;
            //exit track time here;
            Debug.Log("EXIT POINT");
            endTime = Time.time - startTime;
            GetComponent<Collider>().enabled = false;
        //    AnalyticsEvent.Custom(PuzzleProgressManager.instance.eventName, new Dictionary<string, object>
        //    {
        //    { puzzleName, endTime }
        //});

            GameAnalytics.NewDesignEvent(PuzzleProgressManager.instance.eventName + "-" + puzzleName, endTime);
            GameAnalytics.NewDesignEvent("Times_Grabbed", timesGrabbed);
        }
    }
}
