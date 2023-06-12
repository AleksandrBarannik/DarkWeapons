using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//собирает все эффекты и будет возвращать итоговое значение прибавки к статам
public class EffectsProxy : MonoBehaviour,IModifyStats
{
    [SerializeField] 
    private BasicCharacter _owner;
    
    private List<Effect>_allEffectsOnCharacter = new List<Effect>();
    private Inventory Inventory => Game.Instance.Player.Inventory;
    

    public void AddEffect(Effect effect)
    {
        effect.OnApply(_owner);
        _allEffectsOnCharacter.Add(effect);
    }

    public int StrengthBonus
    {
        get
        {
            int totalBonus = 0;
            foreach (var effect in _allEffectsOnCharacter)  //Для любых аур и дебафов
            {
                if (effect is IModifyStats modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.StrengthBonus;
                }
                
            }

            foreach (var item in Inventory.Equipment)// Для экипорованных айтемов эффекты
            {
                foreach (var effect in item.Value.Effects)
                {
                    if (effect is IModifyStats modifyStatsEffect)
                    {
                        totalBonus += modifyStatsEffect.StrengthBonus;
                    }

                }
            }
            return totalBonus;
        }
    }

    public int AgilityBonus
    {
        get
        {
            int totalBonus = 0;
            
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
            int totalBonus = 0;
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
            int totalBonus = 0;
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
            int totalBonus = 0;
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
            int totalBonus = 0;
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

    public int HealthBonus
    {
        get
        {
            int totalBonus = 0;
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.HealthBonus;
                }
            }
            return totalBonus;
        }
    }

    public int ManaBonus
    {
        get
        {
            int totalBonus = 0;
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.ManaBonus;
                }
            }
            return totalBonus; 
        }
        
    }

    public int StaminaBonus
    {
        get
        {
            int totalBonus = 0;
            foreach (var effect in _allEffectsOnCharacter)
            {
                if (effect is ModifyStatsEffect modifyStatsEffect)
                {
                    totalBonus += modifyStatsEffect.StaminaBonus;
                }
            }
            return totalBonus;
        }
    }
}
