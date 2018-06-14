using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public static PauseMenu instance;
    public Panel firstActivePanel;

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
    }

    private void Start()
    {
        gameObject.SetActive(false);
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
}
