using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableItemSceneView : ItemSceneView
{
    protected override bool TryCollect()
    {
        return Game.Instance.Player.Inventory.Add(Item);
    }
}
