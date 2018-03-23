using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USed solely for it's type at the moment.
[RequireComponent(typeof(CanvasGroup))]
public abstract class Panel : MonoBehaviour
{
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit(); 
}
