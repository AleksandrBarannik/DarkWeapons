using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Применяется при поднятии мнгновенно (автоматически)

[Serializable]
public class InstantItem : Item
{
    [SerializeField] private List<InstantEffect> _instantEffects;

    public override void OnCollect()
    {
        base.OnCollect();
        foreach (var instantEffect in _instantEffects)
        {
            instantEffect.OnApply(Game.Instance.Player.Character);
        }
    }

    public override Item Copy()
    {
        var item = new InstantItem();
        FillDataItem(item);
        
        item._instantEffects = new List<InstantEffect>();
        foreach (var instantEffect in _instantEffects)
        {
           item._instantEffects.Add((InstantEffect) instantEffect.Copy());
        }
        
        return item;
    }

}
