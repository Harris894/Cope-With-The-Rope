using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : UIManager {
    public Panel activePanel;


    public void Update() {
        if(activePanel != null)
        activePanel.OnUpdate();
    }

    public void SetActivePanel(Panel panel) {
        if(panel == null) {
            Debug.LogError("Panel not set to an instance of an object!");
            return;
        }
        activePanel.OnExit();

        activePanel = panel;
        activePanel.OnEnter();
    }
}