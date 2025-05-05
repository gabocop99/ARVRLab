using TMPro;
using UnityEngine;

public class XRVisualDebug : MonoBehaviour
{
    [SerializeField] private OculusInputCacheValues questInputCacheValues;

    [Header("Primary Button")]
    [SerializeField] private TextMeshProUGUI _primaryButtonRightText;
    [SerializeField] private TextMeshProUGUI _primaryButtonLeftText;

    [Header("Secondary Button")]
    [SerializeField] private TextMeshProUGUI _secondaryButtonRightText;
    [SerializeField] private TextMeshProUGUI _secondaryButtonLeftText;

    [Header("Triggers")]
    [SerializeField] private TextMeshProUGUI _triggerRightText;
    [SerializeField] private TextMeshProUGUI _triggerLeftText;

    [Header("Grips")]
    [SerializeField] private TextMeshProUGUI _gripRightText;
    [SerializeField] private TextMeshProUGUI _gripLeftText;

    [Header("Thumbsticks")]
    [SerializeField] private TextMeshProUGUI _thumbRightText;
    [SerializeField] private TextMeshProUGUI _thumbLeftText;

    [Header("Menu Button")]
    [SerializeField] private TextMeshProUGUI _menuButtonText;

    void Update()
    {
        if (questInputCacheValues == null) return;

        _primaryButtonRightText.text = $"PrimaryRight: {questInputCacheValues.primaryButtonValueRight:F2}";
        _primaryButtonLeftText.text  = $"PrimaryLeft:  {questInputCacheValues.primaryButtonValueLeft:F2}";

        _secondaryButtonRightText.text = $"SecondaryRight: {questInputCacheValues.secondaryButtonValueRight:F2}";
        _secondaryButtonLeftText.text  = $"SecondaryLeft:  {questInputCacheValues.secondaryButtonValueLeft:F2}";

        _triggerRightText.text = $"TriggerRight: {questInputCacheValues.triggerValueRight:F2}";
        _triggerLeftText.text  = $"TriggerLeft:  {questInputCacheValues.triggerValueLeft:F2}";

        _gripRightText.text = $"GripRight: {questInputCacheValues.gripValueRight:F2}";
        _gripLeftText.text  = $"GripLeft:  {questInputCacheValues.gripValueLeft:F2}";

        Vector2 thumbRight = questInputCacheValues.thumbstickValueRight;
        Vector2 thumbLeft = questInputCacheValues.thumbstickValueLeft;
        _thumbRightText.text = $"ThumbRight: ({thumbRight.x:F2}, {thumbRight.y:F2})";
        _thumbLeftText.text  = $"ThumbLeft:  ({thumbLeft.x:F2}, {thumbLeft.y:F2})";

        _menuButtonText.text = $"Menu: {questInputCacheValues.menuButtonValue:F2}";
    }
}
