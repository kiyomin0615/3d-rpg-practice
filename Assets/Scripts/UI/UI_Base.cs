using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> objectDict = new Dictionary<Type, UnityEngine.Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        // bind all ui elements
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        objectDict.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Utility.FindChildGameObject(gameObject, names[i], true);
            else
                objects[i] = Utility.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"Failed to bind UI object : {names[i]}");
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        if (objectDict.TryGetValue(typeof(T), out UnityEngine.Object[] objects) == false)
            return null;

        return objects[index] as T;
    }
}