using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private PlayerInventory _inventory;
    public int keysNeeded;
    public GameObject door;
    
    private Renderer _doorRend;
    private Collider _doorCol;
    
    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        _doorCol = door.GetComponent<Collider>();
        _doorRend = door.GetComponent<Renderer>();

    }

    void Update()
    {

    }

    private void CheckKeyAmount()
    {
        if (_inventory.keyAmount >= keysNeeded) { OpenDoor(); }
    }
    public void OpenDoor()
    {
        _doorRend.enabled = false;
        _doorCol.isTrigger = true;
    }
}
