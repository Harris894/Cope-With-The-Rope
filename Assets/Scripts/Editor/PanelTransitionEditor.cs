using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;


/// <summary>
/// The custom editor for the PanelTransaction. Makes sure it only show the relevant fields.
/// TODO:
/// -Use alternative fo SetDirty() at the bottom. Should actually not be using this function according to https://docs.unity3d.com/ScriptReference/EditorUtility.SetDirty.html.
/// -Add undo functionality 
/// -Give warning when there is no CanvasGroup on the target object.
/// -Don't display Link button button if it already exists.
/// </summary>
[CustomEditor(typeof(PanelTransition))]
public class PanelTransitionEditor : Editor {

    public override void OnInspectorGUI() {

        PanelTransition pt = (PanelTransition)target;
        Button transButton = pt.GetComponent<Button>();

        //Loop through all transitions if the list exists
        if (pt.transitions != null && pt.transitions.Count > 0) {
            for (int i = 0; i < pt.transitions.Count; i++) {
                EditorGUILayout.Space();

                EditorGUILayout.BeginHorizontal();

                //Set style for the Transition header text
                EditorStyles.label.fontStyle = FontStyle.Bold;
                EditorStyles.label.alignment = TextAnchor.MiddleCenter;
                EditorGUILayout.LabelField("Transition");
                EditorStyles.label.alignment = TextAnchor.MiddleLeft;
                EditorStyles.label.fontStyle = FontStyle.Normal;

                //Style for the mini buttons: remove button,
                GUIStyle miniButton = new GUIStyle(GUI.skin.button);
                miniButton.fixedHeight = 16;
                miniButton.fixedWidth = 16;

                //Style for: Add sub transition button,
                GUIStyle subButton = new GUIStyle(GUI.skin.button);
                subButton.fixedHeight = 16;
                subButton.fixedWidth = 120;
                subButton.alignment = TextAnchor.MiddleRight;


                //Delete current transition
                if (GUILayout.Button(new GUIContent("X", "Delete this transition"), miniButton)) {
                    pt.transitions.RemoveAt(i);
                    continue;
                }
                EditorGUILayout.EndHorizontal();

                //Field for the target Panel.
                pt.transitions[i].target = (Panel)EditorGUILayout.ObjectField("Target", pt.transitions[i].target, typeof(Panel), true);
                Transition transition = pt.transitions[i];

                //Should probably be optimized.
                if (transition.subTransition == null) {
                    transition.subTransition = new List<SubTransition>();
                }

                EditorGUI.indentLevel++;

                //Loop through all the effects of a transition
                if (transition.subTransition.Count > 0) {
                    for (int x = 0; x < transition.subTransition.Count; x++) {
                        EditorGUILayout.Space();
                        SubTransition sub = transition.subTransition[x];

                        EditorGUILayout.BeginHorizontal();
                        sub.transitionType = (TransitionTypes)EditorGUILayout.EnumPopup("Transition Type", sub.transitionType);
                        if (GUILayout.Button(new GUIContent("X", "Delete this transition"), miniButton)) {
                            transition.subTransition.RemoveAt(x);
                        }
                        EditorGUILayout.EndHorizontal();
                        if (sub.transitionType == TransitionTypes.INSTANT) {
                            sub.instantPosition = (RectTransform)EditorGUILayout.ObjectField("Instant Position", sub.instantPosition, typeof(RectTransform), true);
                            sub.instantScale = EditorGUILayout.Slider("Instant Scale", sub.instantScale, 0, 1);
                            sub.instantAlpha = EditorGUILayout.FloatField("Instant Alpha", sub.instantAlpha);
                        }
                        else if (sub.transitionType == TransitionTypes.MOVE) {
                            sub.moveEndPosition = (RectTransform)EditorGUILayout.ObjectField("Move Position", sub.moveEndPosition, typeof(RectTransform), true);
                            sub.moveSpeed = EditorGUILayout.FloatField("Move speed", sub.moveSpeed);
                            sub.moveEase = (Ease)EditorGUILayout.EnumPopup("Move Ease", sub.moveEase);
                        }
                        else if (sub.transitionType == TransitionTypes.FADE) {
                            sub.toFadeValue = EditorGUILayout.Slider("Fade To Value", sub.toFadeValue, 0, 1);
                            sub.fadeSpeed = EditorGUILayout.FloatField("Fade Speed", sub.fadeSpeed);
                            sub.fadeEase = (Ease)EditorGUILayout.EnumPopup("Fade Ease", sub.fadeEase);
                        }
                        else if (sub.transitionType == TransitionTypes.ZOOM) {
                            sub.toZoom = EditorGUILayout.Slider("Scale To", sub.toZoom, 0, 1);
                            sub.zoomSpeed = EditorGUILayout.FloatField("Zoom Speed", sub.zoomSpeed);
                            sub.zoomEase = (Ease)EditorGUILayout.EnumPopup("Zoom Ease", sub.zoomEase);
                        }
                        EditorGUILayout.Space();
                    }
                }

                //After animation text + format.
                EditorStyles.label.fontStyle = FontStyle.Bold;
                EditorGUILayout.LabelField("After Animation");
                EditorStyles.label.fontStyle = FontStyle.Normal;
                transition.enableRaycastAfter = EditorGUILayout.Toggle("Enable Raycast After", transition.enableRaycastAfter);
                transition.setActiveAfter = EditorGUILayout.Toggle("Set Active After", transition.setActiveAfter);


                //Layout for new Sub Transition button.
                GUILayout.BeginHorizontal();
                EditorGUILayout.Space();
                if (GUILayout.Button("Add Sub-Transition", subButton)) {
                    transition.subTransition.Add(new SubTransition());
                }
                EditorGUILayout.Space();
                GUILayout.EndHorizontal();

                EditorGUI.indentLevel--;
                EditorGUILayout.Space();
            }
        }

        //Add new Transition button.
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Transition")) {
            if (pt.transitions == null)
                pt.transitions = new List<Transition>();

            pt.transitions.Add(new Transition());
        }

        //Creates a listener on the UIButton component so that you don't have to set it manually.
        if (transButton) {
            if (GUILayout.Button("Link to Button")) {
                System.Reflection.MethodInfo targetInfo = UnityEvent.GetValidMethodInfo(pt, "PlayTransition", new System.Type[] { });
                Debug.Log(targetInfo);
                UnityAction methodDelegate = System.Delegate.CreateDelegate(typeof(UnityAction), pt, targetInfo) as UnityAction;
                UnityEventTools.AddPersistentListener(transButton.onClick, methodDelegate);
            }
        }
        EditorGUILayout.EndHorizontal();

        //base.DrawDefaultInspector();
        //Set Dirty to persist the data in the created lists. Without this the lists are constantly reset.
        EditorUtility.SetDirty(target);
    }
}
