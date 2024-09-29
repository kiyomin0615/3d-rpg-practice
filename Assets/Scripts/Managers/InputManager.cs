using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Definition.MouseEvent> MouseAction = null;

    bool pressed = false;

    // check user input
    public void OnUpdate() {
        if (Input.anyKey && KeyAction != null) {
            KeyAction.Invoke();
        }

        if (Input.GetMouseButton(1)) {
            MouseAction.Invoke(Definition.MouseEvent.Press);
            pressed = true;
        } else {
            if (pressed) {
                MouseAction.Invoke(Definition.MouseEvent.Click);
            }
            pressed = false;
        }
    }
}
