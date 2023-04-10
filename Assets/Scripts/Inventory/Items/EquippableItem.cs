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
}
