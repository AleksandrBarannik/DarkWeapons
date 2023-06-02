using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ModifyStatsEffect",menuName = "DarkWeapons/Effects/ModifyStatsEffect")]
public class ModifyStatsEffect : Effect,IModifyStats
{
    [SerializeField]
    protected int _strengthBonus;
    public int StrengthBonus => _strengthBonus;
    
    [SerializeField]
    protected int _agilityBonus;
    public int AgilityBonus => _agilityBonus;
    
    [SerializeField]
    protected int _vitalityBonus;
    public int VitalityBonus => _vitalityBonus;
    
    [SerializeField]
    protected int _intelligenceBonus;
    public int IntelligenceBonus => _intelligenceBonus;

    [SerializeField]
    protected int _wisdomBonus;
    public int WisdomBonus => _wisdomBonus;

    [SerializeField]
    protected int _experienceBonus;
    public int ExperienceBonus => _experienceBonus;
    
    [SerializeField]
    protected int _healthBonus;
    public int HealthBonus => _healthBonus;
    
    [SerializeField]
    protected int _manaBonus;
    public int ManaBonus => _manaBonus;
    
    [SerializeField]
    protected int _staminaBonus;
    public int StaminaBonus => _staminaBonus;


    public override Effect Copy()
    {
        var effect = new ModifyStatsEffect();;
        effect._strengthBonus = this._strengthBonus;
        effect._agilityBonus = this._agilityBonus;
        effect._vitalityBonus = this._vitalityBonus;
        effect._intelligenceBonus = this._intelligenceBonus;
        effect._wisdomBonus = this._wisdomBonus;
        effect._experienceBonus = this._experienceBonus;
        effect._healthBonus = this._healthBonus;
        effect._manaBonus = this._manaBonus;
        effect._staminaBonus = this._staminaBonus;
        return effect;
    }
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
