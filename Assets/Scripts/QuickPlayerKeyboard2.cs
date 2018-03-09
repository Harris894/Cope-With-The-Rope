using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPlayerKeyboard2 : MonoBehaviour {

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

        move.x = Input.GetAxis("Horizontal2");

        move.y = Input.GetAxis("Vertical2");
        //Change the button for jumping here.
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
