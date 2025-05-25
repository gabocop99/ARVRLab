using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;

public class SimpleGestureDetector : MonoBehaviour
{
    public XRHandTrackingEvents hand;
    public XRHandPose handPose;
    public Material approvedMaterial;
    public Material startMaterial;
    private XRHandShape _handShape;
    [SerializeField] private GameObject _RaycastOrigin;
    //[SerializeField] private GameObject foo;
    [SerializeField] private LayerMask _layerMask;
    private bool _isPointing;


    private void Awake()
    {
        _RaycastOrigin = GetComponentInChildren<HandRaycastOrigin>().gameObject;
        _handShape = handPose.handShape;
        startMaterial = hand.GetComponentInChildren<Renderer>().material;
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
        bool gestureDetected = hand.handIsTracked && (_handShape != null && _handShape.CheckConditions(eventArgs) &&
                                                      handPose != null && handPose.CheckConditions(eventArgs));
        //CheckCOnditions confronta la Shape selezionata con il data dei Joint della mano per valutare se sia uguale oppure no

        if (gestureDetected)
        {
            hand.GetComponentInChildren<Renderer>().material = approvedMaterial; 
            Ray ray = new Ray(_RaycastOrigin.transform.position, _RaycastOrigin.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask, QueryTriggerInteraction.Collide))
            {
                _isPointing = true;
                //foo.SetActive(true);
            }
        }
        else
        {
            _isPointing = false;
            //foo.SetActive(false);
            hand.GetComponentInChildren<Renderer>().material = startMaterial;
        }
    }
    

    public bool GetIsPointing()
    {
        return _isPointing;
    }
}