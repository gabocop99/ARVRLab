using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPuzzlePiecesSet : MonoBehaviour
{
    private List<GameObject> _checkList = new List<GameObject>();
    private DoorManager _doorManager;
    private bool _isFinished = false;
    void Start()
    {
        #pragma warning disable
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        #pragma warning restore
        _doorManager = GetComponent<DoorManager>();
        foreach (GameObject obj in allObjects)
        {
            if (gameObject.GetComponent<PuzzlePieceCheck>()) { _checkList.Add(obj); }
        }
    }

    void Update()
    {
        CheckBoolean();
        if (_isFinished)
        { _doorManager.OpenDoor(); }
    }

    private void CheckBoolean()
    {
        _isFinished = _checkList
            .All(obj => obj.GetComponent<PuzzlePieceCheck>()?.isPuzzlePlaced == true);
    }
}
