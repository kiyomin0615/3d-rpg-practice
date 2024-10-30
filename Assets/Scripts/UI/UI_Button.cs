using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    enum Images
    {
        ItemIcon
    }

    enum GameObjects
    {
        TestObject
    }

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        // temp
        Get<TextMeshProUGUI>((int)Texts.ScoreText).text = "TEST";
        GameObject itemIcon = Get<Image>((int)Images.ItemIcon).gameObject;
        UI_EventHandler eventHandler = itemIcon.GetComponent<UI_EventHandler>();
        eventHandler.OnDragHandler += (PointerEventData eventData) => { itemIcon.transform.position = eventData.position; };
    }
}
