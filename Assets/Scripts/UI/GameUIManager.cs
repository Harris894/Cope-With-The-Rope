using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public static GameUIManager instance;
    public Text feedbackText;

	void Awake () {
		if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
	}

    public void DisplayFeedbackText(string message)
    {
        feedbackText.text = message;
        CancelInvoke("DisableFeedbackText");
        Invoke("DisableFeedbackText", 10f);
        PauseMenu.instance.SetFeedbackText(message);
    }

    public void DisplayFeedbackText(string message, float duration = 0)
    {
        feedbackText.text = message;
        CancelInvoke("DisableFeedbackText");

        if(duration > 0)
        {
            Invoke("DisableFeedbackText", duration);
        }
    }

    void DisableFeedbackText()
    {
        feedbackText.text = "";
    }

    private void OnLevelWasLoaded(int level)
    {
        GetComponent<Canvas>().enabled = level > 0 ? true : false;
    }
}
