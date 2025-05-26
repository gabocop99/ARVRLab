using UnityEngine;

public class PuzzlePieceCheck : MonoBehaviour
{

    public GameObject puzzlePiece;
    [HideInInspector] public bool isPuzzlePlaced = false;
    private Renderer _rend;
    private Collider _col;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == puzzlePiece.name)
        {
            _rend.enabled = false;
            _col.enabled = false;
            isPuzzlePlaced = true; return;
        }
        isPuzzlePlaced = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPuzzlePlaced)
        {
            _rend.enabled = true;
            _col.enabled = true;
        }
        isPuzzlePlaced = false; 
    }
}
