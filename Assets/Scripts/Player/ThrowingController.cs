using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingController : MonoBehaviour {

    public float throwForce;
    public GrabbingBox grabbingBox;
    public Transform holdingPos;
    public bool isHolding;
    PlayerController otherPlayer;
    Vector3 startPosition;


    private void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (isHolding) {
            otherPlayer.transform.position = holdingPos.position;
        }
    }

    public void Grab() {
        if (isHolding) {
            isHolding = false;
            Rigidbody otherRB = otherPlayer.GetComponent<Rigidbody>();
            otherRB.AddForce((otherPlayer.transform.forward + Vector3.up) * throwForce, ForceMode.Impulse);
            otherPlayer = null;
        }
        else {
            if (grabbingBox.HasPlayer()) {
                isHolding = true;
                otherPlayer = grabbingBox.GetPlayer();
                otherPlayer.transform.position = holdingPos.position;
            }
        }
    }

    public void SetBoxPosition(Vector3 position, bool useOriginalYPos) {
        if (useOriginalYPos) {
            position.y = startPosition.y;
            transform.position = position;
        }else {
            transform.position = position;
        }
    }
	
	
}
