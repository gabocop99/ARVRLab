using UnityEngine;
using UnityEngine.InputSystem;

public class QuestInputLogger : MonoBehaviour
{
    //Inputs are exposed in inspector as InputActions
    public InputAction triggerAction;
    public InputAction gripAction;
    public InputAction thumbstickAction;
    public InputAction primaryButtonAction;
    public InputAction secondaryButtonAction;
    public InputAction menuButtonAction;
    
    //Cache inputs for further read access (for example UI)
    float triggerValue;
    float gripValue;
    Vector2 thumbstickValue;
    bool primaryButtonPressed;
    bool secondaryButtonPressed;
    bool menuButtonPressed;

    void Awake()
    {
        BindAction(triggerAction);
        BindAction(gripAction);
        BindAction(thumbstickAction);
        BindAction(primaryButtonAction);
        BindAction(secondaryButtonAction);
        BindAction(menuButtonAction);
    }

    private void BindAction(InputAction action)
    {
        if (action != null)
        {
            action.performed += LogInput;
            action.canceled += LogInput;
            action.Enable();
        }
    }
    
    private void UnbindAction(InputAction action)
    {
        if (action != null)
        {
            action.performed -= LogInput;
            action.canceled -= LogInput;
            action.Disable();
        }
    }

    private void OnDisable()
    {
        UnbindAction(triggerAction);
        UnbindAction(gripAction);
        UnbindAction(thumbstickAction);
        UnbindAction(primaryButtonAction);
        UnbindAction(secondaryButtonAction);
        UnbindAction(menuButtonAction);
    }

    private void LogInput(InputAction.CallbackContext context)
    {
        Debug.Log($"{context.action.name}: {context.ReadValueAsObject()}");
    }
}
