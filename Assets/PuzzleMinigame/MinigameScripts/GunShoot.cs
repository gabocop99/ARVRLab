using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using CommonUsages = UnityEngine.XR.CommonUsages;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float shootForce = 500f;
    public float bulletLifetime = 5f;
    public TriggerVictoryScreen victoryScreen;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (victoryScreen.isCanvasActive) { return; }
        var rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool aButtonPressed) && aButtonPressed)
        {
            ShootBullet();
            Rigidbody rb = bulletPrefab.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.useGravity = true;
                rb.AddForce(transform.forward * shootForce);
            }

            Destroy(bulletPrefab, bulletLifetime);
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation); 
    }
}
