using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class PanelTransition : MonoBehaviour {
    [SerializeField]
    public List<Transition> transitions;
    private TransitionController transitionController;
    private Panel target;

    private int coroutinesStarted;
    private int coroutinesFinished;
    private bool startedAllTransitions;

    private void Start() {
        transitionController = TransitionController.instance;
    }

    /// <summary>
    /// Plays all made transitions. Loops through the transitions to play the assigned effects.
    /// </summary>
    public void PlayTransition() {
        if (!TransitionController.instance.isAnimating && transitions.Count > 0) {
            TransitionController.instance.isAnimating = true;
            coroutinesStarted = 0;
            coroutinesFinished = 0;
            startedAllTransitions = false;
            foreach (Transition _transition in transitions) {
                target = _transition.target;
                target.gameObject.SetActive(true);
                foreach (SubTransition _subTransition in _transition.subTransition) {
                    switch (_subTransition.transitionType) {
                        case TransitionTypes.INSTANT:
                        transitionController.Instant(target, _subTransition.instantPosition, _subTransition.instantScale, _subTransition.instantAlpha);
                        break;
                        case TransitionTypes.MOVE:
                        transitionController.Move(target, _subTransition.moveEndPosition, _subTransition.moveSpeed, _subTransition.moveEase);
                        break;
                        case TransitionTypes.FADE:
                        transitionController.Fade(target, _subTransition.toFadeValue, _subTransition.fadeSpeed, _subTransition.fadeEase);
                        break;
                        case TransitionTypes.ZOOM:
                        transitionController.Zoom(target, _subTransition.toZoom, _subTransition.zoomSpeed, _subTransition.zoomEase);
                        break;
                    }
                }
                StartCoroutine(AfterTween(_transition, target.gameObject.GetInstanceID()));
                coroutinesStarted++;
            }
            startedAllTransitions = true;
        }
    }

    /// <summary>
    /// Checks if all the transitions on a certain gameobject are done playing.
    /// </summary>
    /// <param name="_transition"> Transition gameobject to be checked.</param>
    /// <param name="objectID">The ID that will be referenced with the tween.</param>
    /// <returns></returns>
    IEnumerator AfterTween(Transition _transition, int objectID) {
        while (DOTween.IsTweening(objectID)) {
            yield return new WaitForEndOfFrame();
        }
        //End of tween

        //When the target to disable is a parent of the object this script is working on disable it as last.
        if(transform.IsChildOf(_transition.target.gameObject.transform)) {
            StartCoroutine(QueueDisableGameobject(_transition));  
        }
        else {
            _transition.target.gameObject.SetActive(_transition.setActiveAfter);
        }
        //Debug.Log(string.Format("Set BlockRaycast to {0} on object {1}", _transition.enableRaycastAfter, _transition.target.gameObject.name));
        _transition.target.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = _transition.enableRaycastAfter;
        TransitionController.instance.isAnimating = false;
        coroutinesFinished++;

    }

    IEnumerator QueueDisableGameobject(Transition transition) {
        while(coroutinesStarted > coroutinesFinished && startedAllTransitions) {
            yield return new WaitForEndOfFrame();
        }
        transition.target.gameObject.SetActive(transition.setActiveAfter);
    }
}
