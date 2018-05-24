using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine;

public class Restart : MonoBehaviour {
    public int restartCount =0;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            restartCount++;
            AnalyticsEvent.Custom("Restarts", new Dictionary<string, object>
            {
                { "Restart_count", restartCount }
            });
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
