using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorplates : MonoBehaviour {

    public static bool pressed1 = false;
    public static bool pressed2 = false;

    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PressurePlate")
        {
            if (pressed1 == false)
            {
                pressed1 = true;
            }

            else
            {
                pressed2 = true;
            }

            if (pressed1 == true && pressed2 == true)
            {
                DestroyObject(door);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PressurePlate")
        {
            pressed1 = false;
        }
    }

}
