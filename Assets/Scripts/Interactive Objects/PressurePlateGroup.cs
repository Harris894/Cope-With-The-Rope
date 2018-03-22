using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PressurePlateGroup : MonoBehaviour {
    public List<PressurePlate> connectedPressurePlates;
    public UnityEvent action;
    int pressedPressurePlates = 0;

    [SerializeField]
    GameObject pressurePlatePrefab;
    int notPressedCount;

    public void Update()
    {
        notPressedCount = 0;
        foreach (PressurePlate pressurePlate in connectedPressurePlates)
        {
            if (!pressurePlate.isPressed)
                notPressedCount++; 
        }
        if(notPressedCount <= 0)
            Activate(); 
    }

    void Activate()
    {
        action.Invoke();
    }
}
