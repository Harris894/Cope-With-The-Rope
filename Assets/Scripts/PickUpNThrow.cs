using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNThrow : MonoBehaviour {

    public ScriptableObjetc myStats;
    public float rayDistance;
    public Transform holder;
    public GameObject player2;

    private bool canPickUp;
    private Rigidbody rb;
   

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        float distance = Vector3.Distance(player2.transform.position, transform.position);
        Debug.Log("" + distance);

        if (distance<2.1f && Input.GetKeyDown(KeyCode.E))
        {
            rb.isKinematic = true;
            //player2.GetComponent<Rigidbody>().isKinematic = true;
            player2.transform.SetParent(holder);
            player2.GetComponent<Rigidbody>().useGravity = false;
            player2.transform.localRotation = transform.rotation;
            player2.transform.position = holder.position;
        }






        //RaycastHit objectHit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * rayDistance, Color.green);

        //if (Physics.Raycast(transform.position, fwd, out objectHit, rayDistance))
        //{
        //    if (objectHit.collider.name=="Player2"&&Input.GetKeyDown(KeyCode.E))
        //    {
        //        objectHit.rigidbody.useGravity = false;
        //        //objectHit.rigidbody.isKinematic = true;
        //        objectHit.transform.position = holder.transform.position;
               
        //    }
        //}

        ////if (canPickUp && Input.GetKeyDown(KeyCode.E))
        ////{
        ////    player2.transform.position
        ////}
    }
}




//raycast in front of each player, if raycast hits other player > canPickUp=true.;
//if canPickUp&&keycode.E=true then otherplayer.position=holder.position;

//if a player isBeingCarried=true&&keycode.E then show a trajectory and addvelocity.forward*speed to throw player.

