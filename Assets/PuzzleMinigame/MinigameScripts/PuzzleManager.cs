using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour, ISolvablePuzzle
{

    public List<PuzzleObject> correctSequence;
    public Color correctColor;
    public Color incorrectColor;
    public int lightPermanence = 1;
    
    
    private int _currentIndex = 0;
    private Material _material;
    private Color _baseColor;

    public bool IsSolved => isPuzzleSolved;
    [HideInInspector] public bool isPuzzleSolved = false;

    private void Start()
    { 
        _material = GetComponent<Renderer>().material;
        _baseColor = _material.color;
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
            StartCoroutine(SetColorAfterDelay(lightPermanence, _baseColor));

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

    private IEnumerator SetColorAfterDelay(int seconds, Color color)
    {
        yield return new WaitForSeconds(seconds);
        ChangeColor(color);
        ResetPuzzle();
    }
}
