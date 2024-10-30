using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    enum Buttons
    {
        ClickButton
    }

    enum Texts
    {
        ClickText,
        ScoreText
    }

    enum GameObjects
    {
        TestObject
    }

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        Get<TextMeshProUGUI>((int)Texts.ScoreText).text = "TEST";
    }

    public void OnButtonClicked()
    {

    }
}
