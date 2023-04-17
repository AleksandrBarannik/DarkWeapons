using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ModifyStatsEffect",menuName = "DarkWeapons/Effects/ModifyStatsEffect")]
public class ModifyStatsEffect : Effect,IModifyStats
{
    [SerializeField]
    private int _strengthBonus;
    public int StrengthBonus => _strengthBonus;
    
    [SerializeField]
    private int _agilityBonus;
    public int AgilityBonus => _agilityBonus;
    
    [SerializeField]
    private int _vitalityBonus;
    public int VitalityBonus => _vitalityBonus;
    
    [SerializeField]
    private int _intelligenceBonus;
    public int IntelligenceBonus => _intelligenceBonus;

    [SerializeField]
    private int _wisdomBonus;
    public int WisdomBonus => _wisdomBonus;

    [SerializeField]
    private int _experienceBonus;
    public int ExperienceBonus => _experienceBonus;
    
    [SerializeField]
    private int _healthBonus;
    public int HealthBonus => _healthBonus;
    
    [SerializeField]
    private int _manaBonus;
    public int ManaBonus => _manaBonus;
    
    [SerializeField]
    private int _staminaBonus;
    public int StaminaBonus => _staminaBonus;
    
    
}

interface IModifyStats
{
    int StrengthBonus { get; }
    int AgilityBonus { get; }
    int VitalityBonus{ get; }
    int IntelligenceBonus { get; }
    int WisdomBonus { get; }
    int ExperienceBonus { get; }
    int HealthBonus { get; }
    int ManaBonus { get; }
    int StaminaBonus { get; }
    
}
