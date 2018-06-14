using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public GameObject destructableObject;


    public void Destruct()
    {
        Instantiate(destructableObject, transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log("triggered");
    }

}
