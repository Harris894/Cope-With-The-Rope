using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine;

public class GlobalAnalytics : MonoBehaviour {

    public static GlobalAnalytics instance;

    private void Awake() {
        if(instance != null) {
            instance = this;
            DontDestroyOnLoad(this);
        }else {
            DestroyImmediate(this);
        }
    }


    private void OnApplicationQuit() {
        AnalyticsEvent.Custom("Total_game_time", new Dictionary<string, object>
        {
            { "Total_time", Time.realtimeSinceStartup }
        });
    }
}
