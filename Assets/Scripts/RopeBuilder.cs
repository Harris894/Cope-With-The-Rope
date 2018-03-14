using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBuilder : MonoBehaviour {

    public GameObject ropePrefab;
    public int ropeLength;
    public float ropePadding;
    public List<GameObject> ropeParts = new List<GameObject>();


	// Use this for initialization
	void Start () {
        CreateRope();
	}

    [ContextMenu("Create rope")]
    void CreateRope() {
        Vector3 createPosition = transform.position;
        float ropeSegmentHeight = ropePrefab.GetComponent<Collider>().bounds.size.y;
        CharacterJoint currentJoint;
        for (int i = 0; i <= ropeLength; i++) {

            
            GameObject newRopePart = Instantiate(ropePrefab);
            createPosition.y -= (newRopePart.GetComponent<Collider>().bounds.size.y + ropePadding);
            print(newRopePart.GetComponent<Collider>().bounds.size.y);
            newRopePart.transform.position = createPosition;
            currentJoint = newRopePart.GetComponent<CharacterJoint>();

            //Vector3 anchorPosition = newRopePart.transform.position;
            currentJoint.autoConfigureConnectedAnchor = true;
            //currentJoint.anchor = new Vector3(anchorPosition.x, newRopePart.GetComponent<Collider>().bounds.size.y + ropePadding / 2,anchorPosition.z);
            //currentJoint.connectedAnchor = currentJoint.anchor;
            Rigidbody connectObject;

            if (ropeParts.Count <= 0) {
                connectObject = gameObject.GetComponent<Rigidbody>();
            }
            else
            {
                connectObject = ropeParts[i - 1].GetComponent<Rigidbody>();
            }


            currentJoint.connectedBody = connectObject;
            ropeParts.Add(newRopePart);
        }
    }
}
