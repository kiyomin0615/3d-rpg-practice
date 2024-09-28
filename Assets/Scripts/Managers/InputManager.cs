using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action UserInput = null;

    // check user input
    public void OnUpdate() {
        if (Input.anyKey == false) {
            return;
        }

        if (UserInput != null) {
            UserInput.Invoke();
        }
    }
}
