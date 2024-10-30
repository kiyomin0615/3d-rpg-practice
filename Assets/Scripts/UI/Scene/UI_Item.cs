using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Item : UI_Base
{
    string name;

    enum GameObjects
    {
        ItemIcon,
        ItemName
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        GameObject itemIcon = Get<GameObject>((int)GameObjects.ItemIcon);
        AddUIEventHandler(itemIcon, (PointerEventData eventData) => { Debug.Log($"Item Clicked : {name}"); }, Definition.UIEvent.Click);

        TextMeshProUGUI itemName = Get<GameObject>((int)GameObjects.ItemName).GetComponent<TextMeshProUGUI>();
        itemName.text = this.name;
    }

    public void SetItemInfo(string name)
    {
        this.name = name;
    }
}
