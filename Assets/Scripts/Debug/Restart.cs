using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using UnityEngine;

public class Restart : MonoBehaviour {
    public int restartCount =0;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            restartCount++;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void OnApplicationQuit()
    {
        GameAnalytics.NewDesignEvent("Times_Restarted", restartCount);
    }
}
