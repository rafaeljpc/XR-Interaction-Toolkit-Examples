using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class POROTest : MonoBehaviour {
    [Space]
    [Header("Controller Actions")]

    [SerializeField]
    [Tooltip("The reference to the action of Press Only")]
    public InputActionReference pressOnly;

    [SerializeField]
    [Tooltip("The reference to the action of Release Only")]
    public InputActionReference releaseOnly;

    [SerializeField]
    [Tooltip("The reference to the action of Press And Release")]
    public InputActionReference pressRelease;

    protected void OnEnable() {
        var po = EnableAction(pressOnly);
        po.started += ctx => LogEvent(ctx, "start PO");
        po.performed += ctx => LogEvent(ctx, "performed PO");


        var ro = EnableAction(releaseOnly);
        ro.started += ctx => LogEvent(ctx, "start RO");
        ro.performed += ctx => LogEvent(ctx, "performed RO");

        var pr = EnableAction(pressRelease);
        pr.started += ctx => LogEvent(ctx, "start PR");
        pr.performed += ctx => LogEvent(ctx, "performed PR");
    }

    private void LogEvent(InputAction.CallbackContext ctx, string msg) {
        Debug.Log($"{msg}\naction={ctx.action}");
    }

    static InputAction EnableAction(InputActionReference actionReference) {
        var action = GetInputAction(actionReference);
        if (action != null && !action.enabled)
            action.Enable();

        return action;
    }

    static InputAction DisableAction(InputActionReference actionReference) {
        var action = GetInputAction(actionReference);
        if (action != null && action.enabled)
            action.Disable();

        return action;
    }

    static InputAction GetInputAction(InputActionReference actionReference) {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
        return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
    }
}
