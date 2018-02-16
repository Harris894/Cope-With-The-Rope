using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPlayerController : MonoBehaviour {

    Vector2 move;
    Rigidbody rb;

    public float speed;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {

        
        if (Input.GetAxis("Left Stick X 1") != 0) {
            move.x = Input.GetAxis("Left Stick X 1");
        }

        if (Input.GetAxis("Left Stick Y 1") != 0) {
            move.y = Input.GetAxis("Left Stick Y 1");
        }
    }

    private void FixedUpdate() {
        //print(move);
        transform.Translate(new Vector3(move.x * speed, 0, move.y * speed), Space.World);
        //rb.AddForce(new Vector3(move.x * speed, 0, move.y * speed), ForceMode.Impulse);

    }
}
