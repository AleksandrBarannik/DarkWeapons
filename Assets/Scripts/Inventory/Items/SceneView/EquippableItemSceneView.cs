using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableItemSceneView : ItemSceneView
{
    [SerializeField] public EquippableItem equippableItem;
    public override Item Item
    {
        get { return equippableItem; }
        set { equippableItem = (EquippableItem) value; }
    }
    protected override bool TryCollect()
    {
        return Game.Instance.Player.Inventory.Add(Item);
    }
}
