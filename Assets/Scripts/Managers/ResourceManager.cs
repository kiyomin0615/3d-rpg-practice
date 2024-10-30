using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string name, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{name}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load the prefab: {name}");
            return null;
        }

        return Object.Instantiate(prefab);
    }

    public void Destroy(GameObject target, float delay = 0f)
    {
        if (target == null)
        {
            return;
        }

        Object.Destroy(target, delay);
    }
}
