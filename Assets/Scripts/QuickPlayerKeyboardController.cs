using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPlayerKeyboardController : MonoBehaviour {

    Vector2 move;
    Rigidbody rb;
    CapsuleCollider col;

    public float speed;
    public float jumpForce;
    public LayerMask groundLayers;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        col = this.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update() {

        move.x = Input.GetAxis("Horizontal");
        
        move.y = Input.GetAxis("Vertical");

        //if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void FixedUpdate() {
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
