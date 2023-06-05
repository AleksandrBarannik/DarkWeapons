using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItemSceneView : ItemSceneView
{
    [SerializeField] public ConsumableItem consumableItem;
    public override Item Item
    {
        get { return consumableItem; }
        set { consumableItem = (ConsumableItem) value; }
    }

    protected override bool TryCollect()
    {
        return Game.Instance.Player.Inventory.Add(Item);
    }
    
    
}
