using System;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public string colliderIgnored;
    private Collider _colliderToIgnore;
    private Collider _col;

    private void Start()
    {
        _col = GetComponent<Collider>();
        _colliderToIgnore = GameObject.Find(colliderIgnored).GetComponent<Collider>();
        Debug.Log(_colliderToIgnore);
        Physics.IgnoreCollision(_col, _colliderToIgnore);
    }

    private void Update()
    {
        Physics.IgnoreCollision(_col, _colliderToIgnore);

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider == _colliderToIgnore)
        {
            Physics.IgnoreCollision(_col, col.collider);
        }
    }


}
