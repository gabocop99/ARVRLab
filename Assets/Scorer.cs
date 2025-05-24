using System;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallIdentifier>())
        {
           ScoreManager.Instance.AddScore();
        }
    }
}
