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

    void Start()
    {

    }

    void Update()
    {
        
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
