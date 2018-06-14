using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {
    public EventSystem eventSystem;

    private void Awake()
    {
        FindPanels();
        //gameObject.SetActive(false);
    }

    void FindPanels() {
        Debug.Log("find panels");
        foreach(Panel panel in GetComponentsInChildren<Panel>(true)) {
            panel.uiManager = this;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
