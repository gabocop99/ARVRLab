using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetHitPuzzle : MonoBehaviour, ISolvablePuzzle
{
    public bool IsSolved => isPuzzleSolved;
    [HideInInspector] public bool isPuzzleSolved;
    private List<TargetHitObject> _children = new List<TargetHitObject>();

    private void Start()
    {
        List<GameObject> children = GetAllChildren(gameObject);

        foreach (GameObject obj in children)
        {
            TargetHitObject objTh = obj.GetComponent<TargetHitObject>();
            if (objTh != null)
            {
                _children.Add(objTh);
            }
        }
    }

    private void Update()
    {
        CheckBoolean();
    }

    private void CheckBoolean()
    {
        isPuzzleSolved = _children
            .All(obj => obj.GetComponent<TargetHitObject>()?.isTargetHit == true);
    }
    
    List<GameObject> GetAllChildren(GameObject parent)
    {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
        }

        return children;
    }
}

