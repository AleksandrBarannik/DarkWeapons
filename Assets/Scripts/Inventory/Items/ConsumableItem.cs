using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Можно применить и исчесзнет (но можно положить в инвентарь)

[Serializable]
public class ConsumableItem : Item
{
    [SerializeField] protected List<InstantEffect> _instantEffects;

    
    public override void OnInteract()
    {
        base.OnInteract();
        
        foreach (var instantEffect in _instantEffects)
        {
            instantEffect.OnApply(Game.Instance.Player.Character);
        }
        
        StackCount--;

    }

    public override Item Copy()
    {
        var item = new ConsumableItem();
        item._id = this._id;
        item._name = this._name;
        item._scaleElement = this._scaleElement;
        item._colliderSize = this._colliderSize;
        item._colliderCenter = this._colliderCenter;
        item._description = this._description;
        item._stackCount = this._stackCount;
        item._stackMaxCount = this._stackMaxCount;
        item._icon = this._icon;
        item._mesh = this._mesh;
        item._material = this._material;
        
        
        item._instantEffects = new List<InstantEffect>();
        foreach (var instantEffect in _instantEffects)
        {
            item._instantEffects.Add((InstantEffect) instantEffect.Copy());
        }
        return item;

    }
}
