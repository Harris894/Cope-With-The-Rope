using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;
using UnityEngine.Analytics;

public class ThrowingController : MonoBehaviour
{

    [Header("Physics")]
    public float throwForceHorizontal;
    public float throwForceVertical;

    [Header("Debug")]
    public bool isHolding;
    public ThrowingController carrier;
    
    [Header("References")]
    public GrabbingBox grabbingBox;
    public Transform holdingPos;
    public ObiRope obiRope;
    public ProPlayerController otherPlayer;

    Vector3 startPosition;
    

    private static int timesGrabbed;


    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            otherPlayer.transform.position = holdingPos.position;
        }
    }

    public void Grab() {
        //Release
        if (carrier != null)
        {
            Debug.Log("Release");
            carrier.Throw(GetComponent<Rigidbody>(), 0f, 0f);
            return;
        }

        if (isHolding) {
            Debug.Log("Throw");
            Rigidbody otherRB = otherPlayer.GetComponent<Rigidbody>();
            Throw(otherRB, throwForceVertical, throwForceHorizontal);
        }
        //Try grabbing
        else {
            if (grabbingBox.HasPlayer()) {
                Debug.Log("Grab");
                isHolding = true;
                //obiRope.enabled = false;
                otherPlayer = grabbingBox.GetPlayer();
                otherPlayer.GetComponent<ThrowingController>().carrier = this;
                otherPlayer.transform.position = holdingPos.position;
                //obiRope.ResetActor();
                //obiRope.UpdateParticlePhases();
                otherPlayer.GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<ObiRigidbody>().kinematicForParticles = true;
                otherPlayer.GetComponent<ObiRigidbody>().kinematicForParticles = true;

                
            }
        }
    }

    public void Throw(Rigidbody otherRB, float verticalForce, float horizontalForce){

        otherRB.isKinematic = false;
        otherRB.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);
        otherRB.AddForce(otherPlayer.lastMoveDirection * horizontalForce, ForceMode.Impulse);
        //StartCoroutine(disableRopeKinematic());
        StartCoroutine(DisableRopeKinematic());
        otherPlayer.GetComponent<ObiRigidbody>().kinematicForParticles = false;
        otherRB.GetComponent<ThrowingController>().carrier = null;

        isHolding = false;
        otherPlayer = null;
    }

    public void SetBoxPosition(Vector3 position, bool useOriginalYPos)
    {
        if (useOriginalYPos)
        {
            position.y = startPosition.y;
            transform.position = position;
        }
        else
        {
            transform.position = position;
        }
    }

    IEnumerator DisableRopeKinematic()
    {
        yield return new WaitForSeconds(1);
        GetComponent<ObiRigidbody>().kinematicForParticles = false;
    }


}
