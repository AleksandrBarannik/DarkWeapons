using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//собирает все эффекты и будет возвращать итоговое значение прибавки к статам
public class EffectsProxy : MonoBehaviour,IModifyStats
{
    [SerializeField] 
    private BasicCharacter _owner;
    
    private List<Effect>_allEffectsOnCharacter = new List<Effect>();
    
    private int totalBonus = 0;

    public void AddEffect(Effect effect)
    {
        effect.OnApply(_owner);
        _allEffectsOnCharacter.Add(effect);
    }

    public int StrengthBonus
    {
        get
        {
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is IModifyStats modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.StrengthBonus;
                }
                
            }
            return totalBonus;
        }
    }

    public int AgilityBonus
    {
        get
        {
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.AgilityBonus;
                }
            }
            return totalBonus;
        }
    }

    public int VitalityBonus 
    {
        get
        {
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.VitalityBonus;
                }
            }
            return totalBonus;
        }
    }

    public int IntelligenceBonus
    {
        get
        {
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.VitalityBonus;
                }
            }
            return totalBonus;
            
        }
    }

    public int WisdomBonus
    {
        get
        {
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.VitalityBonus;
                }
            }
            return totalBonus;
            
        }
    }
    
    public int ExperienceBonus
    {
        get
        {
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.ExperienceBonus;
                }
            }
            return totalBonus;
            
        }
    }
}
