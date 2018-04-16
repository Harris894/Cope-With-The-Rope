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
    public bool moveRelativeToCamera;


    public float speed;
    public float jumpForce;
    public LayerMask groundLayers;
    public Vector3 forceInAir;
    public Vector3 lastMoveDirection;

    private bool canMove;

    ThrowingController throwingController;
    float grabbingPointY;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        throwingController = GetComponent<ThrowingController>();
        canMove = true;
        
    }

    private void Start() {
        Debug.Log(throwingController);
        grabbingPointY = throwingController.transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        if (useController) {
            if (canMove) {
                move.Set(Input.GetAxis(string.Format("Left Stick X {0}", controllerNumber)), 0, Input.GetAxis(string.Format("Left Stick Y {0}", controllerNumber)));
            }

            if (Input.GetButtonDown(string.Format("X{0}", controllerNumber))) {
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
            else {
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }

            if (Input.GetKeyDown(KeyCode.Backspace)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if (!useController) {
            if (canMove) {
                //move.x = Input.GetAxis(string.Format("Horizontal{0}", controllerNumber));
                //move.y = Input.GetAxis(string.Format("Vertical{0}", controllerNumber));
                move = new Vector3(Input.GetAxis(string.Format("Horizontal{0}", controllerNumber)), 0, Input.GetAxis(string.Format("Vertical{0}", controllerNumber)));
            }

            if (Input.GetKeyDown(KeyCode.Q) && controllerNumber == 1) {
                if (throwingController != null)
                    throwingController.Grab();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                canMove = false;
                rb.isKinematic = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                canMove = true;
                rb.isKinematic = false;
            }


            if (moveRelativeToCamera) {
                move = Camera.main.transform.rotation * move;
                move.y = 0;
            }

            lastMoveDirection = move;
            Vector3 temp = transform.position + move;
            temp.y = grabbingPointY;
            throwingController.grabbingBox.transform.position = temp;
            throwingController.SetBoxPosition(transform.position + move, true);
        }
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

        //if (move != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(move);
        //    //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.15f);
        //    rb.rotation = newRotation;
        //}

    }

    
}
