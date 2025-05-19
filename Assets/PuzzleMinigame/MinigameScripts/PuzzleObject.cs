using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    private bool _isTriggered = false;
    private PuzzleManager _puzzleManager;

    private void Start()
    {
        _puzzleManager = GetComponentInParent<PuzzleManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_puzzleManager.isPuzzleSolved) { return; }
        if (other.CompareTag("Player") && !_isTriggered)
        {
            _isTriggered = true;
            _puzzleManager.RegisterTrigger(this);
        }
    }
    public void ResetTrigger()
    {
        _isTriggered = false;
    }
}
