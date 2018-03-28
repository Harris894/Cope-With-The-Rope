using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class lengthController : MonoBehaviour
{

    public float speed = 1;
    ObiRopeCursor cursor;
    ObiRope rope;

    void Start()
    {
        cursor = GetComponent<ObiRopeCursor>();
        rope = GetComponent<ObiRope>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            cursor.ChangeLength(rope.RestLength - speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
            cursor.ChangeLength(rope.RestLength + speed * Time.deltaTime);
    }
}
