using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public GameObject RootPool { get; private set; }

    class Pool
    {
        public GameObject Original { get; private set; } // prefab object
        public GameObject Root { get; private set; } // root object

        Stack<Poolable> poolableStack = new Stack<Poolable>();
    }

    Dictionary<string, Pool> poolDict = new Dictionary<string, Pool>();

    public void Init()
    {
        if (RootPool == null)
        {
            RootPool = new GameObject() { name = "@RootPool" };
            Object.DontDestroyOnLoad(RootPool);
        }
    }

    public GameObject GetOriginal(string name)
    {
        return null;
    }

    public void Push(Poolable poolable)
    {

    }

    public Poolable Pop(GameObject origin, Transform parent = null)
    {
        return null;
    }
}
