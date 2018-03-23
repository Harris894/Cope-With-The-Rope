using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour {

    public Panel activePanel;

    public void Update() {
        activePanel.OnUpdate();
    }

    public void SetActivePanel(Panel panel) {
        activePanel.OnExit();

        activePanel = panel;
        activePanel.OnEnter();
    }
}
