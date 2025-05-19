using UnityEngine;

public class KeyScript : MonoBehaviour
{ 
    private PlayerInventory _inventory;
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        { return; }

        _inventory.keyAmount++;
        Destroy(this.gameObject);
    }
}
