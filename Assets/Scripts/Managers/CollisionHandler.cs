using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public ScriptableObject myStats;

    
    public CapsuleCollider p1upperCollider;
    public CapsuleCollider p1lowerCollider;
    public CapsuleCollider p1groundCheck;




    // Use this for initialization
    void Start () {
        //p1groundCheck.GetComponent<CapsuleCollider>();
        CapsuleCollider p1groundCheck = GetComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        p1lowerCollider.GetComponent<CapsuleCollider>();
        p1upperCollider.GetComponent<CapsuleCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (p1groundCheck.gameObject.tag=="Terrain")
        {
            Debug.Log("collided floor");
        }
    }
}
