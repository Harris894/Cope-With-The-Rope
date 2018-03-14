using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class TransitionController : MonoBehaviour {

    public static TransitionController instance { get; private set; }
    public bool isAnimating = false;

    private void Awake()
    {
        //Should only ever be one instance only.
        if (!TransitionController.instance) {
            instance = this;
        }else {
            Debug.LogError("Second instance of TransitionController found on : " + this.gameObject.name);
            DestroyImmediate(this);  
        }
        
    }

    /// <summary>
    /// Places the object instantly at the given position with the given scalen and the given alpha value.
    /// </summary>
    /// <param name="target">Object to adjust</param>
    /// <param name="position">Object will be set to this position</param>
    /// <param name="toScale">Object will be set to this scale</param>
    /// <param name="alpha">Object will be set to this alpha value</param>
    public void Instant(Panel target, RectTransform position, float toScale, float alpha)
    {
        //Weird bug with instant moving. Makes it seem jumpy and interferes with other MOVE tweens.
        //target.GetComponent<RectTransform>().anchoredPosition = position.anchoredPosition; //OLD
        
        RectTransform rectTransform = target.GetComponent<RectTransform>();
        rectTransform.DOMove(position.position, 0f).SetId(target.gameObject.GetInstanceID());

        target.transform.localScale = new Vector3(toScale, toScale, toScale);
        target.GetComponent<CanvasGroup>().alpha = alpha;
    }

    /// <summary>
    /// Moves the target to a certain position over a certain time. 
    /// </summary>
    /// <param name="target">Object to move</param>
    /// <param name="endPosition">Object will move to this position</param>
    /// <param name="time">Object will move over this duration</param>
    /// <param name="ease"></param>
    public void Move(Panel target, RectTransform endPosition, float time, Ease ease)
    {
        RectTransform rectTransform = target.GetComponent<RectTransform>();
        rectTransform.DOMove(endPosition.position, time).SetEase(ease).SetId(target.gameObject.GetInstanceID());
    }

    /// <summary>
    /// Fades the target to a certain value over a certain time.
    /// </summary>
    /// <param name="target">Object to fade.</param>
    /// <param name="toFade">Object will fade to this value.</param>
    /// <param name="speed">Object will fade over this duration</param>
    /// <param name="ease"></param>
    public void Fade(Panel target,float toFade, float speed, Ease ease)
    {
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        canvasGroup.DOFade(toFade, speed).SetEase(ease).SetId(target.gameObject.GetInstanceID());
    }

    /// <summary>
    /// Scales the target to a certain value over a certain time.
    /// </summary>
    /// <param name="target">Object to move.</param>
    /// <param name="toScale">Target will scale to this value.</param>
    /// <param name="time">Target will scale over this duration</param>
    /// <param name="ease"></param>
    public void Zoom(Panel target,  float toScale, float time, Ease ease)
    {
        target.transform.DOScale(toScale, time).SetEase(ease).SetId(target.gameObject.GetInstanceID());
    }
}

public enum TransitionTypes
{
    INSTANT,
    MOVE,
    FADE,
    ZOOM,
}
