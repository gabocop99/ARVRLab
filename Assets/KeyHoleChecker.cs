using System;
using UnityEngine;

public class KeyHoleChecker : MonoBehaviour
{
    [SerializeField] public bool _hasBeenInserted = false;
    [SerializeField] private Material _material;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Key>())
        {
            _hasBeenInserted = true;
            Destroy(other.gameObject);
            GetComponent<MeshRenderer>().material = _material;
            GetComponent<Collider>().enabled = false;
        }
    }
}