using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Definition.SceneType.Game;
        Manager.UI.OpenSceneUI<UI_Inventory>();
    }

    public override void Clear()
    {
        Debug.Log("Game Scene Clear.");
    }
}
