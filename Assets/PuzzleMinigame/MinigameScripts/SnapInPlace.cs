using UnityEngine;
using UnityEngine.EventSystems;

public class SnapInPlace : MonoBehaviour, ISolvablePuzzle
{    
    public string objectName;

    public bool IsSolved => isPuzzleSolved;
    [HideInInspector] public bool isPuzzleSolved = false;
    private bool _isObjectInPlace = false;
    

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
