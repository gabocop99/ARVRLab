using UnityEngine;

// ReSharper disable All

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }

    [SerializeField] private int _score;
    [SerializeField] private Transform _spawnPointKey;
    [SerializeField] private GameObject _key;

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

    private void ReduceScore()
    {
        _score = _score - 1;
    }

    void Update()
    {
        if (_score >= 10)
        {
            Instantiate(_key, transform.position, Quaternion.identity);
        }
    }
}