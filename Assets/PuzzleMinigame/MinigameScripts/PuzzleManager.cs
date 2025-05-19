using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour, ISolvablePuzzle
{

    public List<PuzzleObject> correctSequence;
    
    private int _currentIndex = 0;
    private Material _material;
    public Color correctColor;
    public Color incorrectColor;
    public bool IsSolved => isPuzzleSolved;
    [HideInInspector] public bool isPuzzleSolved = false;

    private void Start()
    { 
        _material = GetComponent<Renderer>().material;
    }
    public void RegisterTrigger(PuzzleObject obj)
    {
        if (obj == correctSequence[_currentIndex])
        {
            _currentIndex++;
            if (_currentIndex >= correctSequence.Count)
            {
                ChangeColor(correctColor);
                isPuzzleSolved = true;
            }
        }
        else
        {
            ChangeColor(incorrectColor);    
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        _currentIndex = 0;
        foreach (var obj in correctSequence)
        { obj.ResetTrigger(); }
    }

    private void ChangeColor(Color color)
    { _material.color = color; }
}
