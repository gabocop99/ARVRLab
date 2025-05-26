using UnityEngine;

public class TargetHitObject : MonoBehaviour
{
    
    [HideInInspector] public bool isTargetHit = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            isTargetHit = true;
            Destroy(other.gameObject);
        }
    }
}
