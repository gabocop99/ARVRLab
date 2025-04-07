using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlaneAnchored : MonoBehaviour
{
    [Tooltip("Prefab of the object to place on detected plane.")]
    public GameObject ObjectToPlace;

    private ARRaycastManager _arRaycastManager;
    private ARAnchorManager _arAnchorManager;
    private readonly List<ARRaycastHit> _arRaycastHits = new List<ARRaycastHit>();
    private Vector2 _touchPosition;
    private bool _spawnRequested;


    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arAnchorManager = GetComponent<ARAnchorManager>();
    }

    private void Update()
    {
        _spawnRequested = false;

        if (Touchscreen.current != null)
        {
            if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                _touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                _spawnRequested = true;
            }
        }
        else
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _touchPosition = Mouse.current.position.ReadValue();
                _spawnRequested = true;
            }
        }

        if (!_spawnRequested)
        {
            return;
        }

        if (_arRaycastManager.Raycast(_touchPosition, _arRaycastHits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = _arRaycastHits[0].pose;

            ARPlane hitPlane = _arRaycastHits[0].trackable.GetComponent<ARPlane>();

            if (hitPlane != null)
            {
                ARAnchor anchor = _arAnchorManager.AttachAnchor(hitPlane, hitPose);

                if (anchor != null)
                {
                    if (ObjectToPlace != null)
                    {
                        Instantiate(ObjectToPlace, anchor.transform.position, anchor.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
                    }
                }
            }
        }
    }
}