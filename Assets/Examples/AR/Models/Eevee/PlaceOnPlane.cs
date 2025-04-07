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
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 touchPosition;

    private bool spawnRequested;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
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
            Instantiate(objectToPlane, hitPose.position, hitPose.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
    }
}
