using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItemSceneView : ItemSceneView
{
    protected override bool CanCollect()
    {
        //и  добавляем в инвентарь и возвращаем что добавили
        return Game.Instance.Player.Inventory.Add(Item);
    }
}
