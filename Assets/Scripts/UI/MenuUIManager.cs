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
        activePanel.OnExit();

        activePanel = panel;
        activePanel.OnEnter();
    }
}
 c