using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingBridge : MonoBehaviour
{

    private int weight = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            weight = weight + 1;

            if (weight == 2)
            {
                gameObject.SetActive(false);
                weight = 0;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            weight = weight - 1;

        }
    }
}

