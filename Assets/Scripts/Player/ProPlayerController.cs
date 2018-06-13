using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ProUserInput))]
public class ProPlayerController : MonoBehaviour {

    [Header("Settings")]
    public bool moveRelativeToCamera;
    public float groundCheckRayExtendDistance;

    [Header("Physics")]
    public float speed;
    public float jumpPower;
    public float jumpCooldown;
    public float airMovementPenalty;
    public float airDashPower;
    [Range(0,4)]
    public float gravityMultiplier;
    public LayerMask groundLayers;

    [Header("Debug")]
    [SerializeField]
    private bool inAir;
    private float lastJumpTime = 0;
    private bool canMove;
    private Vector3 move;

    //References
    [Header("References")]
    [SerializeField] Transform cam;
    Rigidbody rb;
    ProUserInput proUserInput;
    ThrowingController throwingController;
    Collider characterCollider;

    

    [Header("Other")]
    public Vector3 lastMoveDirection;


    //Input
    float i_jump;
    float i_moveForward, i_moveRight;
    bool i_primaryAction, i_secondaryAction;

    public void SendInput(float jump, float moveForward, float moveRight, bool primaryAction, bool secondaryAction) {
        i_jump = jump;
        i_moveForward = moveForward;
        i_moveRight = moveRight;
        i_primaryAction = primaryAction;
        i_secondaryAction = secondaryAction;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();
        proUserInput = GetComponent<ProUserInput>();
        throwingController = GetComponent<ThrowingController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Apply the movement
        if (moveRelativeToCamera) {
            if (cam == null) {
                cam = Camera.main.transform;
            }
            Vector3 camDirection = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = (i_moveForward * camDirection * speed + i_moveRight * Camera.main.transform.right * speed) * Time.deltaTime;
        }
        else {
            //Set movement values
            move.z = i_moveForward * speed;
            move.x = i_moveRight * speed;
        }

        //Add extra gravity for the player.
        rb.velocity += Physics.gravity * gravityMultiplier;

        //Groundcheck
        Debug.DrawRay(characterCollider.bounds.center,
            Vector3.down * (characterCollider.bounds.extents.y + groundCheckRayExtendDistance), Color.red);
        if (Physics.Raycast(characterCollider.bounds.center,
            Vector3.down * (characterCollider.bounds.extents.y + groundCheckRayExtendDistance),2f,groundLayers)) {
            inAir = false;
            Debug.Log("Hit ground");
        }
        else {
            inAir = true;
        }

        //front hit test 
        bool airHit = false;
        RaycastHit hit;
        //Debug.DrawRay(characterCollider.bounds.center, transform.position + move.normalized, Color.magenta);
        Debug.DrawRay(characterCollider.bounds.center, move * 10, Color.magenta);
        if(Physics.Raycast(characterCollider.bounds.center, move * 10, out hit, 10f, groundLayers)) {
            if (inAir) {
                airHit = true;
            }
        }
        

        if(i_primaryAction) {
            Debug.Log("Primary Action");
            if(throwingController != null)
            throwingController.Grab();
        }

        //Jumping
        if (i_jump > 0 && !inAir && Time.time > lastJumpTime + jumpCooldown) {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            lastJumpTime = Time.time;
        }
        //Airdash
        else if (i_jump > 0 && inAir && Time.time > lastJumpTime + jumpCooldown) {
            rb.AddForce((Vector3.up * 0.1f + move) * airDashPower, ForceMode.Impulse);
            lastJumpTime = Time.time;
            Debug.Log("Air dash");
        }

        //Apply the movement to the object
        if (!inAir) {
            rb.MovePosition(transform.position + move);
            lastMoveDirection = move;
        }
        else {
            //rb.MovePosition(transform.position + lastMoveDirection);
            if(!airHit) {
                rb.MovePosition(transform.position + lastMoveDirection + (move * airMovementPenalty));
            }
           
        }

        //Position the grabbing box
        throwingController.grabbingBox.transform.position = (transform.position + move.normalized);

    }
}
