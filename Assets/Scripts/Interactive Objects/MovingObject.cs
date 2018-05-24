using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour {

    public bool active;
    public float speed;
    
    
    public List<Transform> nodeList = new List<Transform>();
    public float distanceMargin;

    private Rigidbody rb;
    public int currentNode = 0;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (active) {
            Vector3 direction = (nodeList[currentNode].transform.position - transform.position).normalized * speed;
            rb.velocity = direction;
            //Debug.Log(Vector3.Distance(transform.position, nodeList[currentNode].transform.position));
            if (Vector3.Distance(transform.position, nodeList[currentNode].transform.position) < distanceMargin) {
                //Debug.Log("Close enuf");
                currentNode = currentNode == nodeList.Count - 1 ? 0 : currentNode + 1;

            }
        }
        else {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
