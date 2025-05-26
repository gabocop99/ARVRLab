using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class TriggerVictoryScreen : MonoBehaviour
{
    public GameObject canvas;
    [HideInInspector] public bool isCanvasActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true); 
            isCanvasActive = true;
        }
    }

    private void Update()
    {
        if (!isCanvasActive) { return; }
        var rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool aButtonPressed) && aButtonPressed)
        {
            Debug.Log("Reload Scene");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

    }
}
