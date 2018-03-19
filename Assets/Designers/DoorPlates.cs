using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlates : MonoBehaviour
{

    public static bool pressed1 = false;
    public static bool pressed2 = false;

    public GameObject door;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressed1 = false;
        }
    }

}

