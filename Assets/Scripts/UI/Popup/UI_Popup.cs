using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public virtual void Init()
    {
        Manager.UI.SetCanvas(gameObject, true);
    }

    public virtual void Close()
    {
        Manager.UI.ClosePopupUI(this);
    }
}
