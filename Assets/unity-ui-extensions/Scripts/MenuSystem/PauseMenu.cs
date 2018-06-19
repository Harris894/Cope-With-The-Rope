using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public static PauseMenu instance;
    public Panel firstActivePanel;

    [SerializeField]
    private Text feedBackText;
    MenuUIManager menuUIManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        menuUIManager = GetComponent<MenuUIManager>();
        SetFeedbackText("");
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetFeedbackText(string message)
    {
        feedBackText.text = "Objective: \n \n" + message;
    }


    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
        Time.timeScale = state ? 0 : 1;
        LowPass();

        if (state)
        {
            menuUIManager.SetActivePanel(firstActivePanel);
        }
    }

    void LowPass()
    {
        if (Time.timeScale==0)
        {
            paused.TransitionTo(.01f);
        }
        else
        {
            unpaused.TransitionTo(.01f);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
