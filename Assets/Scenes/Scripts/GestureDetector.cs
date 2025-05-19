using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;

public class GestureDetector : MonoBehaviour
{
    public XRHandTrackingEvents hand;
    public XRHandPose handPose;
    private XRHandShape _handShape;

    private void Awake()
    { _handShape = handPose.handShape; }
    void OnEnable()
    {
        if (hand == null) { return; }
        hand.jointsUpdated.RemoveListener(OnJointsUpdated);
    }

    // Update is called once per frame
    private void OnJointsUpdated(XRHandJointsUpdatedEventArgs eventArgs)
    {
        bool gestureDetected = 
            hand.handIsTracked &&
            _handShape.CheckConditions(eventArgs) &&
            handPose.CheckConditions(eventArgs);
        Debug.Log($"Gesture Detected: {gestureDetected}");
    }
}
