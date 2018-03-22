using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//USed solely for it's type at the moment.
[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    [HideInInspector]
    public UIManager uiManager;
    [SerializeField]
     private Selectable firstSelectedElement;

    public virtual void OnEnter() {
        uiManager.eve
    }

    public virtual void OnUpdate() {

    }

    public virtual void OnExit() {

    }
}
