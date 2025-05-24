using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;

public class SimpleGestureDetector : MonoBehaviour
{

    public XRHandTrackingEvents hand;
    public XRHandPose handPose;
    public Material approvedMaterial;
    private XRHandShape _handShape;
    private GameObject _check;


    private void Awake()
    {
        _handShape = handPose.handShape;
    }

    private void OnEnable()
    {
        if (hand != null)
        {
            hand.jointsUpdated.AddListener(OnJointsUpdated);
        }
    }
    private void OnDisable()
    {
        if (hand != null)
        {
            hand.jointsUpdated.RemoveListener(OnJointsUpdated);
        }
    }


    private void OnJointsUpdated(XRHandJointsUpdatedEventArgs eventArgs)
    {
        bool gestureDetected= hand.handIsTracked && (_handShape != null && _handShape.CheckConditions(eventArgs) && handPose != null && handPose.CheckConditions(eventArgs));
        //CheckCOnditions confronta la Shape selezionata con il data dei Joint della mano per valutare se sia uguale oppure no
        hand.GetComponentInChildren<Renderer>().material = approvedMaterial;
        if (gestureDetected)
        {
            _check.SetActive(true);
        }
        else
        {
            _check.SetActive(false);
        }
        
    }
}
