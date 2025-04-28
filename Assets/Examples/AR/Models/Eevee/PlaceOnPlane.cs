using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    public GameObject objectToPlane;
    
    private ARRaycastManager arRaycastManager;
    private ARAnchorManager anchorManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 touchPosition;

    private bool spawnRequested;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }
    
    void Update()
    {
        spawnRequested = false;

        if (Touchscreen.current != null)
        {
            if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                spawnRequested = true;
            }
        }

        else
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                touchPosition = Mouse.current.position.ReadValue();
                spawnRequested = true;
            }
        }


        if (!spawnRequested)
        {
            return;
        }
        
        if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            ARPlane hitPlane = hits[0].trackable.GetComponent<ARPlane>();    //trackable classe generica per ogni cosa tracciabile


            if (hitPlane != null)
            {
                ARAnchor anchor = anchorManager.AttachAnchor(hitPlane, hitPose);
                if(anchor != null)
                {
                    if (objectToPlane != null)
                    {
                        Instantiate(objectToPlane, anchor.transform.position, anchor.transform.rotation* Quaternion.Euler(0,180,0), anchor.transform);
                    }
                }
            }
            Instantiate(objectToPlane, hitPose.position, hitPose.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
    }
}
