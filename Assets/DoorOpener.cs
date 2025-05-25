using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private KeyHoleChecker[] _Keyholes;
    [SerializeField] private GameObject _DoorLeft;
    [SerializeField] private GameObject _DoorRight;

    private bool _isDoorClosed = true;

    private Vector3 _offSet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _offSet = new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_Keyholes[0]._hasBeenInserted || !_Keyholes[2]._hasBeenInserted || !_Keyholes[2]._hasBeenInserted ||
            !_isDoorClosed) return;
        
        _isDoorClosed = false;
        _DoorLeft.transform.position = Vector3.MoveTowards(_DoorLeft.transform.localPosition, _DoorLeft.transform.localPosition - _offSet, 0.1f * Time.deltaTime);
        _DoorRight.transform.position = Vector3.MoveTowards(_DoorRight.transform.localPosition, _DoorLeft.transform.localPosition + _offSet, 0.1f*Time.deltaTime);
    }
}