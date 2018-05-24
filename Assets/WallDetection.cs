using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{

    private RayCaster wallRay;
    public Transform playerPos;

    MeshRenderer wall;

    void Start()
    {
        wallRay = new RayCaster();
        wallRay.OnRayEnter += WallRay_OnEnter;
        wallRay.OnRayExit += WallRay_OnExit;
        wallRay.layermask = RayCaster.GetLayerMask("Wall");
        wallRay.StartTransform = playerPos.transform;
        wallRay.EndTransform = transform;
    }

    void Update()
    {
        
        wallRay.CastLine();
        Debug.DrawRay(playerPos.transform.position, transform.position - playerPos.transform.position, Color.green);
    }

    void WallRay_OnEnter(Collider collider)
    {
        
        
        wall = collider.transform.gameObject.GetComponent<MeshRenderer>();
        wall.enabled = false;
    }

    void WallRay_OnExit(Collider collider)
    {
   
        wall = collider.transform.gameObject.GetComponent<MeshRenderer>();
        wall.enabled = true;
    }
}