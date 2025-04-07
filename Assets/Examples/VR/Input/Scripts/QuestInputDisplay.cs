using UnityEngine;
using UnityEngine.UI;

public class QuestInputDisplay : MonoBehaviour
{
    public OculusInputCacheValues inputManager;
    
    public Slider triggerSlider;
    public Slider gripSlider;
    public Toggle primaryButtonToggle;
    public Toggle secondaryButtonToggle;
    public Toggle menuButtonToggle;
    public ThumbstickUIGizmo thumbstickIndicator;
    
    void Update()
    {
        if (!inputManager) return;

        triggerSlider.value = inputManager.triggerValue;
        gripSlider.value = inputManager.gripValue;
        thumbstickIndicator.SetValue(inputManager.thumbstickValue);
        primaryButtonToggle.isOn = inputManager.primaryButtonPressed;
        secondaryButtonToggle.isOn = inputManager.secondaryButtonPressed;
        menuButtonToggle.isOn = inputManager.menuButtonPressed;
    }
}