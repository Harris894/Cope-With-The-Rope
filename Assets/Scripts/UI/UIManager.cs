using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {
    public EventSystem eventSystem;

    private void Start()
    {
        FindPanels();
    }

    void FindPanels() {
        foreach(Panel panel in GetComponentsInChildren<Panel>()) {
            panel.uiManager = this;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
