using UnityEngine;

public class SnapInPlace : MonoBehaviour
{    
    public string objectName;

    [HideInInspector] public bool isPuzzleSolved = false;
    public bool IsSolved => isPuzzleSolved;
    private bool _isObjectInPlace = false;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (_isObjectInPlace) {return;}
        
        if (other.name == objectName)
        {
            isPuzzleSolved = true;
            _isObjectInPlace = true;
        }
    }
}
