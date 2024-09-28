using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Instance {
        get {
            Init();
            return instance;
        }
    }

    private InputManager input = new InputManager();
    public static InputManager Input {
        get {
            return Instance.input;
        }
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        Input.OnUpdate();
    }

    static void Init() {
        GameObject manager = GameObject.Find("@Manager");
        if (manager == null)
        {
            manager = new GameObject("@Manager");
            manager.AddComponent<Manager>();
        }
        DontDestroyOnLoad(manager);
        instance = manager.GetComponent<Manager>();
    }
}
