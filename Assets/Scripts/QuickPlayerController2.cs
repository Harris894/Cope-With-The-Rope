using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPlayerController2 : MonoBehaviour
{

    Vector2 move;
    Rigidbody rb;

    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxis("Left Stick X 2") != 0)
        {
            move.x = Input.GetAxis("Left Stick X 2");
        }

        if (Input.GetAxis("Left Stick Y 2") != 0)
        {
            move.y = Input.GetAxis("Left Stick Y 2");
        }
    }

    private void FixedUpdate()
    {
        //print(move);
        Vector3 newMove = new Vector3(move.x, 0, move.y);
        //transform.Translate(new Vector3(move.x * speed, 0, move.y * speed), Space.World);
        rb.MovePosition(transform.position + newMove * speed * Time.deltaTime);

    }
}
