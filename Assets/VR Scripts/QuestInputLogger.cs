using UnityEngine;
using UnityEngine.InputSystem;

public class QuestInputLogger : MonoBehaviour
{
    public InputAction triggerAction;
    public InputAction gripAction;
    public InputAction thumbstickAction;
    public InputAction primaryButtonAction;
    public InputAction secondaryButtonAction;
    public InputAction menuButtonAction;

    private void Awake()
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

    private void LogInput(InputAction.CallbackContext ctx)
    {
        Debug.Log($"{ctx.action.name}: {ctx.ReadValueAsObject()}");
    }
}
