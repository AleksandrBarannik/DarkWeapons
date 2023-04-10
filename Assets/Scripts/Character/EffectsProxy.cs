using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//собирает все эффекты и будет возвращать итоговое значение прибавки к статам
public class EffectsProxy : MonoBehaviour,IModifyStats
{
    [SerializeField] 
    private BasicCharacter _owner;
    
    private List<Effect>_allEffectsOnCharacter = new List<Effect>();

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
}
