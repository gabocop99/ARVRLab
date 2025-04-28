using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class XRVisualDebug : MonoBehaviour
{
    [SerializeField] private OculusInputCacheValues questInputChaceValues;

    [Header("Primary Buttons")] [SerializeField]
    private GameObject _primaryButtonRight;

    [SerializeField] private GameObject _primaryButtonLeft;

    [Header("Secondary Buttons")] [SerializeField]
    private GameObject _secondaryButtonRight;

    [SerializeField] private GameObject _secondaryButtonLeft;

    [Header("Triggers Buttons")] [SerializeField]
    private GameObject _triggerRight;

    [SerializeField] private GameObject _triggerLeft;

    [Header("Grips Buttons")] [SerializeField]
    private GameObject _gripRight;

    [SerializeField] private GameObject _gripLeft;

    [Header("Thumb sticks")] [SerializeField]
    private GameObject _thumbRight;

    [SerializeField] private GameObject _thumbLeft;

    [Header("Grip Buttons")] [SerializeField]
    private GameObject _menuButton;

    void Start()
    {
        questInputChaceValues = FindFirstObjectByType<OculusInputCacheValues>();
    }

    // Update is called once per frame
    void Update()
    {
        foo(_primaryButtonRight);
    }


    private void foo(GameObject ogetto)
    {
        // Debug.Log(ogetto);
        var textComponent = ogetto.GetComponent<TextMeshProUGUI>();
        var value = questInputChaceValues.primaryButtonAction.ReadValue<float>();
        Debug.Log(value.ToString());
        textComponent.text = value.ToString();
    }
}