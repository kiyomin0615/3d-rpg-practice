using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> objectDict = new Dictionary<Type, UnityEngine.Object[]>();

    enum Buttons
    {
        ClickButton
    }

    enum Texts
    {
        ClickText,
        ScoreText
    }

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        // bind all ui elements
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        objectDict.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            objects[i] = Utility.FindChild<T>(gameObject, names[i], true);
        }
    }

    public void OnButtonClicked()
    {
    }
}
