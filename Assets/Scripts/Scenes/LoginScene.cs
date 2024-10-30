using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    public override void ClearScene()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Definition.SceneType.Login;
    }
}
