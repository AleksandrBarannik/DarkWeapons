using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItemSceneView : ItemSceneView
{
    
    protected override bool TryCollect()
    {
        return Game.Instance.Player.Inventory.Add(Item);
    }
    
    
}
