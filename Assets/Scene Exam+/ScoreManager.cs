using UnityEngine;

// ReSharper disable All

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }

    [SerializeField] private int _score;
    [SerializeField] private Transform _spawnPointKey;
    [SerializeField] private GameObject _key;
    private bool scoreReached = false;

    private void Awake()
    {
        if (Instance == null && Instance != this)
            Instance = this;
        else
            Destroy(this.gameObject);
    }


    public void AddScore()
    {
        _score += 1;
    }
    
    void Update()
    {
        if (_score >= 10 && !scoreReached)
        {
            scoreReached = true;
            FindFirstObjectByType<KeyInstantier>().InstantiateKey(_key, _spawnPointKey);
        }
    }
}