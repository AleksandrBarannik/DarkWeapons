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
        if (_stackCount <= 0)
        {
            Game.Instance.Player.Inventory.Remove(this);
        }
        Game.Instance.Player.Inventory.UpdateInventory();
    }

    public override Item Copy()
    {
        var item = new ConsumableItem();
        FillDataItem(item);

        item._instantEffects = new List<InstantEffect>();
        
        foreach (var instantEffect in _instantEffects)
        {
            item._instantEffects.Add((InstantEffect) instantEffect.Copy());
        }
        
        return item;

    }
}
