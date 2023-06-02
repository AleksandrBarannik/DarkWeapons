using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot
{
    Empty = 0,
    LeftHand = 1,
    RightHand = 2,
    Head = 3,
    Chest = 4,
    Legs = 5
}

[Serializable]
public class EquippableItem : Item
{
    [SerializeField] private EquipmentSlot _slot;
    public EquipmentSlot Slot => _slot;

    [SerializeField]
    private List<Effect> _effects;

    public override void OnCollect()
    {
        base.OnCollect();
        foreach (var effect in _effects)
        {
            Game.Instance.Player.Character.Stats.EffectsProxy.AddEffect(effect);
        }
        
    }

    public override Item Copy()
    {
        var item = new EquippableItem();
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
        item._slot = this._slot;

        
        item._effects = new List<Effect>();
        foreach (var effect in _effects)
        {
            item._effects.Add(effect.Copy());
        }
        
        return item;
    }
}
