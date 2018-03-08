using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class SubTransition{
    public TransitionTypes transitionType;


    //Instant
    public RectTransform instantPosition;
    public float instantScale = 1;
    public float instantAlpha = 1;

    //Move
    public RectTransform moveEndPosition;
    public float moveSpeed;
    public Ease moveEase;

    //Fade
    public float toFadeValue;
    public float fadeSpeed;
    public Ease fadeEase;

    //Zoom
    public float toZoom;
    public float zoomSpeed;
    public Ease zoomEase;
}
