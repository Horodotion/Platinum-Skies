using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Enum represents all of the different types of stats in the game.
// If more stats are needed, the list can be extended with new variables.
public enum StatType
{
    health,
    damage,
    speed,
    firingSpeed,
    score
}

// The factions determine which other factions can be damaged by attacks
public enum Faction
{
    player,
    enemy,
    other
}

// This is an inbetween step to suppliment a dictionary in the inspector.
[Serializable] public class StatValue
{
    public StatType stat;
    public float value;
}

[Serializable]
[CreateAssetMenu(menuName = "Stat set")]
public class Stats : ScriptableObject
{
    public List<StatValue> baseStatList;
    public List<StatValue> maxStatList;

    public Dictionary<StatType, float> stat = new Dictionary<StatType, float> {};
    public Dictionary<StatType, float> baseStat = new Dictionary<StatType, float> {};
    public Dictionary<StatType, float> maxStat = new Dictionary<StatType, float> {};


    public void SetStats()
    {
        stat = NewDictionary(baseStatList);
        baseStat = NewDictionary(baseStatList);
        maxStat = NewDictionary(maxStatList);
    }

    public Dictionary<StatType, float> NewDictionary(List<StatValue> statValues)
    {
        Dictionary<StatType, float> dict = new Dictionary<StatType, float> {};

        foreach (StatType newStat in System.Enum.GetValues(typeof(StatType)))
        {
            dict.Add(newStat, 0);
        }

        for (int i = 0; i < statValues.Count; i++)
        {
            dict[statValues[i].stat] = statValues[i].value;
        }

        return dict;
    }

    public void ResetStat(StatType statType)
    {
        stat[statType] = baseStat[statType];
    }

    public void MaximizeStat(StatType statType)
    {
        stat[statType] = maxStat[statType];
    }
}