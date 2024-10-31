using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public void Init()
    {
        TextAsset textAsset = Manager.Resource.Load<TextAsset>("Data/StatData");
        StatData statData = JsonUtility.FromJson<StatData>(textAsset.text); // Deserialize
        foreach (Stat stat in statData.stats)
        {
            Debug.Log($"LEVEL: {stat.level}, HP: {stat.level}, ATTACK: {stat.attack}");
        }
    }
}
