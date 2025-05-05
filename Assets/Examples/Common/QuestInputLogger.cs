using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OculusInputCacheValues : MonoBehaviour
{
    [Header("Trigger Action")]
    public InputAction triggerLeft;
    public InputAction triggerRight;

    [Header("Grip Action")]
    public InputAction gripLeft;
    public InputAction gripRight;

    [Header("Thumbstick Action")]
    public InputAction thumbstickLeft;
    public InputAction thumbstickRight;

    [Header("Primary Button Action")]
    public InputAction primaryButtonLeft;
    public InputAction primaryButtonRight;

    [Header("Secondary Button Action")]
    public InputAction secondaryButtonLeft;
    public InputAction secondaryButtonRight;

    [Header("Menu Button Action")]
    public InputAction menu;

    // Cache values
    public float triggerValueLeft { get; private set; }
    public float triggerValueRight { get; private set; }

    public float gripValueLeft { get; private set; }
    public float gripValueRight { get; private set; }

    public Vector2 thumbstickValueLeft { get; private set; }
    public Vector2 thumbstickValueRight { get; private set; }

    public float primaryButtonValueLeft { get; private set; }
    public float primaryButtonValueRight { get; private set; }

    public float secondaryButtonValueLeft { get; private set; }
    public float secondaryButtonValueRight { get; private set; }

    public float menuButtonValue { get; private set; }

    void Awake()
    {
        BindAction(triggerLeft,  ctx => triggerValueLeft = ctx.ReadValue<float>(),  _ => triggerValueLeft = 0);
        BindAction(triggerRight, ctx => triggerValueRight = ctx.ReadValue<float>(), _ => triggerValueRight = 0);

        BindAction(gripLeft,  ctx => gripValueLeft = ctx.ReadValue<float>(),  _ => gripValueLeft = 0);
        BindAction(gripRight, ctx => gripValueRight = ctx.ReadValue<float>(), _ => gripValueRight = 0);

        BindAction(thumbstickLeft,  ctx => thumbstickValueLeft = ctx.ReadValue<Vector2>(),  _ => thumbstickValueLeft = Vector2.zero);
        BindAction(thumbstickRight, ctx => thumbstickValueRight = ctx.ReadValue<Vector2>(), _ => thumbstickValueRight = Vector2.zero);

        BindAction(primaryButtonLeft,  ctx => primaryButtonValueLeft = ctx.ReadValue<float>(),  _ => primaryButtonValueLeft = 0);
        BindAction(primaryButtonRight, ctx => primaryButtonValueRight = ctx.ReadValue<float>(), _ => primaryButtonValueRight = 0);

        BindAction(secondaryButtonLeft,  ctx => secondaryButtonValueLeft = ctx.ReadValue<float>(),  _ => secondaryButtonValueLeft = 0);
        BindAction(secondaryButtonRight, ctx => secondaryButtonValueRight = ctx.ReadValue<float>(), _ => secondaryButtonValueRight = 0);

        BindAction(menu, ctx => menuButtonValue = ctx.ReadValue<float>(), _ => menuButtonValue = 0);
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
        triggerLeft?.Disable();
        triggerRight?.Disable();
        gripLeft?.Disable();
        gripRight?.Disable();
        thumbstickLeft?.Disable();
        thumbstickRight?.Disable();
        primaryButtonLeft?.Disable();
        primaryButtonRight?.Disable();
        secondaryButtonLeft?.Disable();
        secondaryButtonRight?.Disable();
        menu?.Disable();
    }
}
