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
    public int VitalityBonus => vitalityBonus;
    
    [SerializeField]
    private int intelligenceBonus;
    public int IntelligenceBonus => intelligenceBonus;

    [SerializeField]
    private int wisdomBonus;
    public int WisdomBonus => wisdomBonus;

    [SerializeField]
    private int experienceBonus;

    public int ExperienceBonus => experienceBonus;
}

interface IModifyStats
{
    int StrengthBonus { get; }
    int AgilityBonus { get; }
    int VitalityBonus{ get; }
    int IntelligenceBonus { get; }
    int WisdomBonus { get; }
    int ExperienceBonus { get; }
    
}
