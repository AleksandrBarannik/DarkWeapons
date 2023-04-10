using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ModifyStatsEffect",menuName = "Effects/ModifyStatsEffect")]
public class ModifyStatsEffect : Effect,IModifyStats
{
    [SerializeField]
    private int strengthBonus;
    public int StrengthBonus => strengthBonus;
    
    [SerializeField]
    private int agilityBonus;
    public int AgilityBonus => agilityBonus;
    
    [SerializeField]
    private int vitalityBonus;
    
    [SerializeField]
    private int intelligenceBonus;

    [SerializeField]
    private int wisdomBonus;
    
}

interface IModifyStats
{
    int StrengthBonus { get; }
}
