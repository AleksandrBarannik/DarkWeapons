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

    public List<Effect> Effects => _effects;


    public override void OnInteract()
    {
        base.OnInteract();
        Equip();
    }

    public void Equip()
    {
        Game.Instance.Player.Inventory.Equip(this);
        /*
         foreach (var effect in _effects)
         {
             Game.Instance.Player.Character.Stats.EffectsProxy.AddEffect(effect);
         }
         */
     }
     
     public void UnEquip()
     {
        /* foreach (var effect in _effects)
         {
             Game.Instance.Player.Character.Stats.EffectsProxy.AddEffect(effect);
         }
         */
    }

    public override Item Copy()
    {
        var item = new EquippableItem();
        FillDataItem(item);
        item._slot = _slot;
        
        

        item._effects = new List<Effect>();
        foreach (var effect in _effects)
        {
            item._effects.Add(effect.Copy());
        }
        
        return item;
    }
}
