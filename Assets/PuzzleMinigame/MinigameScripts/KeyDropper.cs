using UnityEngine;

public class KeyDropper : MonoBehaviour
{
    public MonoBehaviour puzzleReference;
    private ISolvablePuzzle _puzzle;
    
    public GameObject rewardPrefab;
    public Transform spawnPoint;
    private bool _hasSpawned = false;
    void Start()
    {
        _puzzle = puzzleReference as ISolvablePuzzle;
        if (_puzzle == null)
        {
            Debug.LogError("Puzzle reference does not implement ISolvablePuzzle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasSpawned && _puzzle != null && _puzzle.IsSolved)
        {
            Instantiate(rewardPrefab, spawnPoint.position, spawnPoint.rotation);
            _hasSpawned = true;
        }
    }
}
