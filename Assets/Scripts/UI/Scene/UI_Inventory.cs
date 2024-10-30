using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);

        foreach (Transform child in gridPanel.transform)
        {
            Manager.Resource.Destroy(child.gameObject);
        }

        for (int i = 0; i < 12; i++)
        {
            GameObject item = Manager.Resource.Instantiate("UI/Scene/UI_Item");
            item.transform.SetParent(gridPanel.transform, false); // worldPositionStays가 true이면, item의 scale이 변경된다
            UI_Item itemComponent = Utility.GetOrAddComponent<UI_Item>(item);
            itemComponent.SetItemInfo($"ITEM {i + 1}");
        }
    }
}
