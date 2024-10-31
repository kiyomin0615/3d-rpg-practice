using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Manager Singleton
    private static Manager instance;
    public static Manager Instance
    {
        get
        {
            Init();
            return instance;
        }
    }

    // Input Manager
    private InputManager input = new InputManager();
    public static InputManager Input
    {
        get
        {
            return Instance.input;
        }
    }

    // Resource Manager
    private ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource
    {
        get
        {
            return Instance.resource;
        }
    }

    // UI Manager
    private UIManager ui = new UIManager();
    public static UIManager UI
    {
        get
        {
            return Instance.ui;
        }
    }

    // Scene Manager Extended
    private SceneManagerEx scene = new SceneManagerEx();
    public static SceneManagerEx Scene
    {
        get
        {
            return Instance.scene;
        }
    }

    // Audio Manager
    private AudioManager audio = new AudioManager();
    public static AudioManager Audio
    {
        get
        {
            return Instance.audio;
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

    static void Init()
    {
        GameObject manager = GameObject.Find("@Manager");
        if (manager == null)
        {
            manager = new GameObject("@Manager");
            manager.AddComponent<Manager>();
        }
        DontDestroyOnLoad(manager);
        instance = manager.GetComponent<Manager>();

        instance.audio.Init();
    }

    public static void Clear()
    {
        Input.Clear();
        Audio.Clear();
        Scene.Clear();
        UI.Clear();
    }
}
