using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ProUserInput))]
public class ProPlayerController : MonoBehaviour {

    [Header("Settings")]
    public bool moveRelativeToCamera;

    [Header("Physics")]
    public float speed;
    public float jumpPower;
    [Range(0,4)]
    public float gravityMultiplier;
    public LayerMask groundLayers;

    private bool canMove;
    private Vector3 move;

    //References
    [Header("References")]
    [SerializeField] Transform cam;
    Rigidbody rb;
    ProUserInput proUserInput;


    //Input
    float i_jump;
    float i_moveForward, i_moveRight;

    public void SendInput(float jump, float moveForward, float moveRight) {
        i_jump = jump;
        i_moveForward = moveForward;
        i_moveRight = moveRight;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        proUserInput = GetComponent<ProUserInput>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity += Physics.gravity * gravityMultiplier;

        if(i_jump > 0) {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        }

        //if(i_moveForward != 0) {

        //}

        //if(i_moveRight != 0) {
        //    //vecto
        //}
        move.z = i_moveForward * speed;
        move.x = i_moveRight * speed;
        if (moveRelativeToCamera) {
            Vector3 camDirection = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = i_moveForward * camDirection * speed + i_moveRight * Camera.main.transform.right * speed;
        }

        rb.MovePosition(transform.position + move);
    }
}
