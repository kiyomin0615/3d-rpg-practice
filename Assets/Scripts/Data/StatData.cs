using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatData : IData<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> ToDict()
    {
        Dictionary<int, Stat> statDict = new Dictionary<int, Stat>();

        foreach (Stat stat in stats)
        {
            statDict.Add(stat.level, stat);
        }

        return statDict;
    }
}
