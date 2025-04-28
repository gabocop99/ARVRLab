using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OculusInputCacheValues : MonoBehaviour
{
    //Inputs are exposed in inspector as InputActions
    public InputAction triggerAction;
    public InputAction gripAction;
    public InputAction thumbstickAction;
    public InputAction primaryButtonAction;
    public InputAction secondaryButtonAction;
    public InputAction menuButtonAction;
    
    //Cache inputs for further read access (for example UI)
    public float triggerValue { get; private set; }
    public float gripValue { get; private set; }
    public Vector2 thumbstickValue { get; private set; }
    public bool primaryButtonPressed { get; private set; }
    public bool secondaryButtonPressed { get; private set; }
    public bool menuButtonPressed { get; private set; }

    void Awake()
    {
        BindAction(triggerAction, OnTriggerPerformed, OnTriggerCanceled);
        BindAction(gripAction, OnGripPerformed, OnGripCanceled);
        BindAction(thumbstickAction, OnThumbstickPerformed, OnThumbstickCanceled);
        BindAction(primaryButtonAction, OnPrimaryButtonPerformed, OnPrimaryButtonCanceled);
        BindAction(secondaryButtonAction, OnSecondaryButtonPerformed, OnSecondaryButtonCanceled);
        BindAction(menuButtonAction, OnMenuButtonPerformed, OnMenuButtonCanceled);
    }

    private void BindAction(InputAction action, Action<InputAction.CallbackContext> performed, Action<InputAction.CallbackContext> canceled)
    {
        if (action != null)
        {
            action.performed += performed;
            action.canceled += canceled;
            action.Enable();
        }
    }

    private void OnDisable()
    {
        triggerAction?.Disable();
        gripAction?.Disable();
        thumbstickAction?.Disable();
        primaryButtonAction?.Disable();
        secondaryButtonAction?.Disable();
        menuButtonAction?.Disable();
    }

    private void OnTriggerPerformed(InputAction.CallbackContext context) 
    {
        triggerValue = context.ReadValue<float>();
    }

    
    private void OnGripPerformed(InputAction.CallbackContext context) 
    {
        gripValue = context.ReadValue<float>();
    }
    
    
    private void OnThumbstickPerformed(InputAction.CallbackContext context) 
    {
        thumbstickValue = context.ReadValue<Vector2>();
    }
    
    
    private void OnPrimaryButtonPerformed(InputAction.CallbackContext context) 
    {
        primaryButtonPressed = true;
    }
    
    private void OnSecondaryButtonPerformed(InputAction.CallbackContext context) 
    {
        secondaryButtonPressed = true;
    }
    
    private void OnMenuButtonPerformed(InputAction.CallbackContext context) 
    {
        menuButtonPressed = true;
    }
    
    private void OnGripCanceled(InputAction.CallbackContext context)
    {
        gripValue = 0;
    }
    
    private void OnTriggerCanceled(InputAction.CallbackContext context)
    {
        triggerValue = 0;
    }
    
    private void OnThumbstickCanceled(InputAction.CallbackContext context)
    {
        thumbstickValue = Vector2.zero;
    }
    
    private void OnPrimaryButtonCanceled(InputAction.CallbackContext context)
    {
        primaryButtonPressed = false;
    }
    
    private void OnSecondaryButtonCanceled(InputAction.CallbackContext context)
    {
        secondaryButtonPressed = false;
    }
    
    private void OnMenuButtonCanceled(InputAction.CallbackContext context)
    {
        menuButtonPressed = false;
    }

}
