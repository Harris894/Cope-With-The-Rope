using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPlayerController2 : MonoBehaviour
{

    Vector2 move;
    Rigidbody rb;
    CapsuleCollider col;

    public float speed;
    public float jumpForce;
    public LayerMask groundLayers;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = this.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {


        move.x = Input.GetAxis("Left Stick X 2");

        
        move.y = Input.GetAxis("Left Stick Y 2");

        if (IsGrounded() && Input.GetButtonDown("A2"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("X2"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        }

        if (Input.GetButtonUp("X2"))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newMove = new Vector3(move.x, 0, move.y);
        rb.MovePosition(transform.position + newMove * speed * Time.deltaTime);

    }


    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
