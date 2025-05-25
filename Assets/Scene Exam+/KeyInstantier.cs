using UnityEngine;

public class KeyInstantier : MonoBehaviour
{

    public void InstantiateKey(GameObject prefabKey, Transform spawnPointKey)
    {
        Instantiate(prefabKey, spawnPointKey.position, Quaternion.identity);
    }
    
}