using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandling : MonoBehaviour {

    Animator anim;

    public float rayLength;

    public float ikWeight=1;

    public Transform leftIKTarget;
    public Transform rightIKTarget;

    Vector3 lFpos;
    Vector3 rFpos;

    Quaternion lFrot;
    Quaternion rFrot;

    float lFWeight;
    float rFWeight;

    Transform leftFoot;
    Transform rightFoot;

    public float offsetY;

    public LayerMask affectedLayers;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();

        leftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        rightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

        lFrot = leftFoot.rotation;
        rFrot = rightFoot.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit leftHit;
        RaycastHit rightHit;

        Vector3 lpos = leftFoot.TransformPoint(Vector3.zero);
        Vector3 rPos = rightFoot.TransformPoint(Vector3.zero);

        if (Physics.Raycast(lpos, -Vector3.up, out leftHit, rayLength, affectedLayers))
        {
            lFpos = leftHit.point;
            lFrot = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
        }

        if (Physics.Raycast(rPos, -Vector3.up, out rightHit, rayLength, affectedLayers))
        {
            rFpos = rightHit.point;
            rFrot = Quaternion.FromToRotation(transform.up, rightHit.normal) * transform.rotation;
        }

        Debug.DrawRay(lpos, -Vector3.up, Color.blue);
    }

    void OnAnimatorIK()
    {
        lFWeight = anim.GetFloat("LeftFoot");
        rFWeight = anim.GetFloat("RightFoot");

        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, lFWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rFWeight);

        anim.SetIKPosition(AvatarIKGoal.LeftFoot, lFpos + new Vector3(0,offsetY,0));
        anim.SetIKPosition(AvatarIKGoal.RightFoot, rFpos + new Vector3(0, offsetY, 0));

        anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, lFWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rFWeight);

        anim.SetIKRotation(AvatarIKGoal.LeftFoot, lFrot);
        anim.SetIKRotation(AvatarIKGoal.RightFoot, rFrot);
    }
}
