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
    HandArmor = 4,
    Chest = 5,
    Legs = 6,
    Belt = 7,
    Amulet = 8,
    RingOne = 9,
    RingTwo = 10
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
        if (!Game.Instance.Player.Inventory.IsEquipped(this))
        {
            Equip();
        }
        else
        {
            UnEquip();
        }
        Game.Instance.Player.Character.Stats.UpdateStats();
        
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
         Game.Instance.Player.Inventory.UnEquip(this);
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
