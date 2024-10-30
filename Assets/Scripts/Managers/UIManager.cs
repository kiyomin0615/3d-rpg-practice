using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int order = 0;

    Stack<UI_Popup> popupStack = new Stack<UI_Popup>();

    public T OpenPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject ui = Manager.Resource.Instantiate($"UI/Popup/{name}"); // Assets/Resources/Prefabs/UI/Popup/{name}
        T popup = Utility.GetOrAddComponent<T>(ui);
        popupStack.Push(popup);

        return popup;
    }

    public void ClosePopupUI()
    {
        if (popupStack.Count == 0)
            return;

        UI_Popup popup = popupStack.Pop();
        Manager.Resource.Destroy(popup.gameObject);
        popup = null;
        order--;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (popupStack.Count == 0)
            return;

        if (popupStack.Peek() != popup)
        {
            Debug.Log("Failed to close the popup UI.");
            return;
        }

        ClosePopupUI();
    }

    public void CloseAllPopupUI()
    {
        while (popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }
}
