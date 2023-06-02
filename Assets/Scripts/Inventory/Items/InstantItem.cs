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
