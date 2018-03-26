using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Vector3 move;
    Rigidbody rb;
    CapsuleCollider col;
    Camera mainCam;


    public int controllerNumber;
    public bool useController;


    public float speed;
    public float jumpForce;
    public LayerMask groundLayers;

    private bool canMove;
    

    //private Vector3 camRotation;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        canMove = true;
        
        

        //useController = Input.GetJoystickNames().Length >= controllerNumber ? true : false;
        //Debug.Log(Input.GetJoystickNames().Length);

    }

    // Update is called once per frame
    void Update () {
        

        if (useController)
        {
            if (canMove)
            {
                //move.x = Input.GetAxis(string.Format("Left Stick X {0}", controllerNumber));
                //move.y = Input.GetAxis(string.Format("Left Stick Y {0}", controllerNumber));
                move = new Vector3(Input.GetAxis(string.Format("Left Stick X {0}", controllerNumber)), 0, Input.GetAxis(string.Format("Left Stick Y {0}", controllerNumber)));
                
                

            }
            

            //if (IsGrounded() && Input.GetButtonDown(string.Format("A{0}", controllerNumber)))
            //{
            //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //}

            if (Input.GetButtonDown(string.Format("X{0}", controllerNumber)))
            {
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            //if (move.y + move.x == 0)
            //{
            //    rb.constraints = RigidbodyConstraints.FreezeRotationY;
            //}
        }
        else if(!useController)
        {
            if (canMove)
            {
                //move.x = Input.GetAxis(string.Format("Horizontal{0}", controllerNumber));
                //move.y = Input.GetAxis(string.Format("Vertical{0}", controllerNumber));
                move = new Vector3(Input.GetAxis(string.Format("Horizontal{0}", controllerNumber)), 0, Input.GetAxis(string.Format("Vertical{0}", controllerNumber)));
            }

            //if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            //{
            //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //}

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                canMove = false;
                rb.isKinematic = true; 
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                canMove = true;
                rb.isKinematic = false; 
            }
        }

        if(Physics.CheckBox(transform.position, Vector3.one * 0.5f, transform.rotation, groundLayers)) {
            //Debug.Log(string.Format("Player {0} IsGrounded",controllerNumber));
            rb.mass = 3;
        }else {
            rb.mass = 0.1f; 
        }
        move = Camera.main.transform.rotation * move;
        move.y = 0;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawCube(transform.position, Vector3.one * 0.3f);
    }

    private void FixedUpdate()
    {
        //Vector3 newMove = new Vector3(cameraX, 0, move.y);
        rb.MovePosition(transform.position + move * speed * Time.deltaTime);

        //rb.MovePosition((camRotation.forward + move.y) * speed * Time.deltaTime);
        //rb.MovePosition((camRotation.right + move.x) * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(move);
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.15f);
            rb.rotation = newRotation;
        }

    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
