using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//USed solely for it's type at the moment.
[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    [HideInInspector]
    public UIManager uiManager;
    [SerializeField]
     private Selectable firstSelectedElement;

    public virtual void OnEnter() {
        gameObject.SetActive(true);
        if(firstSelectedElement != null)
        {
            Debug.Log("Set first selected element");
            uiManager.eventSystem.SetSelectedGameObject(firstSelectedElement.gameObject);
        }
    }

    public virtual void OnUpdate() {

    }

    public virtual void OnExit() {
        gameObject.SetActive(false);
    }
}
