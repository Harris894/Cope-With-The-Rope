using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;
using GameAnalyticsSDK;

public class ThrowingController : MonoBehaviour
{
    
    public float throwForceHorizontal;
    public float throwForceVertical;
    public GrabbingBox grabbingBox;
    public Transform holdingPos;
    public bool isHolding;
    public PlayerController otherPlayer;
    Vector3 startPosition;
    public ObiRope obiRope;

    public int timesGrabbed;
    public PuzzleProgressPoint progressPoint;


    private void Start()
    {
        startPosition = transform.position;
        
        //progressPoint = GetComponent<PuzzleProgressPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            otherPlayer.transform.position = holdingPos.position;
        }
    }

    public void Grab()
    {
        //Throw
        if (isHolding)
        {
            isHolding = false;
            Rigidbody otherRB = otherPlayer.GetComponent<Rigidbody>();

            otherRB.AddForce(Vector3.up * throwForceVertical, ForceMode.Impulse);
            otherRB.AddForce(otherPlayer.lastMoveDirection * throwForceHorizontal, ForceMode.Impulse);
            //StartCoroutine(disableRopeKinematic());
            StartCoroutine(DisableRopeKinematic());
            otherPlayer.GetComponent<ObiRigidbody>().kinematicForParticles = false;

            otherPlayer = null;


        }
        //Try grabbing
        else
        {
            if (grabbingBox.HasPlayer())
            {
                isHolding = true;
                //obiRope.enabled = false;

                otherPlayer = grabbingBox.GetPlayer();
                otherPlayer.transform.position = holdingPos.position;
                //obiRope.ResetActor();
                obiRope.UpdateParticlePhases();
                GetComponent<ObiRigidbody>().kinematicForParticles = true;
                otherPlayer.GetComponent<ObiRigidbody>().kinematicForParticles = true;

                //Unity anal
                //AnalyticsEvent.Custom(PuzzleProgressManager.instance.eventName, new Dictionary<string, object>
                //   {
                //    { "Times_grabbed", timesGrabbed }
                //});
                progressPoint.timesGrabbed++;

            }
        }
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
