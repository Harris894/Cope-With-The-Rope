using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Vector2 move;
    Rigidbody rb;
    CapsuleCollider col;

    public int controllerNumber;
    public bool useController;


    public float speed;
    public float jumpForce;
    public LayerMask groundLayers;

    private bool canMove;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        canMove = true;
    }

    // Update is called once per frame
    void Update () {
        if (useController)
        {
            if (canMove)
            {
                move.x = Input.GetAxis(string.Format("Left Stick X {0}", controllerNumber));
                move.y = Input.GetAxis(string.Format("Left Stick Y {0}", controllerNumber));
            }
            

            //if (IsGrounded() && Input.GetButtonDown(string.Format("A{0}", controllerNumber)))
            //{
            //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //}

            if (Input.GetButtonDown(string.Format("X{0}", controllerNumber)))
            {
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }

            if (Input.GetButtonUp(string.Format("X{0}", controllerNumber)))
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
        else //If using keyboard
        {
            if (canMove)
            {
                move.x = Input.GetAxis(string.Format("Horizontal{0}", controllerNumber));
                move.y = Input.GetAxis(string.Format("Vertical{0}", controllerNumber));
            }

            //if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            //{
            //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //}

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                rb.isKinematic = true;
                canMove = false;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                rb.isKinematic = false;
                canMove = true;
            }
        }

        
        
    }

    private void FixedUpdate()
    {
        Vector3 newMove = new Vector3(move.x, 0, move.y);
        rb.MovePosition(transform.position + newMove * speed * Time.deltaTime);

        if (newMove != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(newMove);
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
