using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, Stat> statDict = new Dictionary<int, Stat>();

    public void Init()
    {
        TextAsset textAsset = Manager.Resource.Load<TextAsset>("Data/StatData");
        StatData statData = JsonUtility.FromJson<StatData>(textAsset.text); // Deserialize

        foreach (Stat stat in statData.stats)
        {
            statDict.Add(stat.level, stat);
        }
    }
}
