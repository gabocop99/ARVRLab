using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Hands;

public class WaigerBehaviour : MonoBehaviour
{
    [SerializeField] private Collider _myTrigger;
    [SerializeField] private Transform[] Waypoints;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private bool _canInteract;

    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private GameObject _leftHand;


    private int currentWaypointIndex = 0;
    private bool isMoving = false;

    void Start()
    {
        _myTrigger = GetComponent<Collider>();
        dialogueCanvas = FindFirstObjectByType<DialogueWaigerIdentifier>().gameObject;
        dialogueCanvas.SetActive(false);
        //_rightHand = FindFirstObjectByType<RightHand>().gameObject;
        //_leftHand = FindFirstObjectByType<LeftHand>().gameObject;
    }

    void Update()
    {
        if (_canInteract)
        {
            if (_leftHand.GetComponent<SimpleGestureDetector>()
                    .GetIsPointing() || _rightHand.GetComponent<SimpleGestureDetector>()
                    .GetIsPointing())
            {
                isMoving = true;
                dialogueCanvas.SetActive(false);
                _myTrigger.enabled = false;
            }
        }

        if (isMoving && currentWaypointIndex < Waypoints.Length)
        {
            Transform target = Waypoints[currentWaypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= Waypoints.Length)
                {
                    isMoving = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            dialogueCanvas.SetActive(true);
            _canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueCanvas.SetActive(false);
        _canInteract = false;
    }
}