using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Применяется при поднятии мнгновенно (автоматически)

[Serializable]
public class InstantItem : Item
{
    [SerializeField] private List<InstantEffect> _instantEffects;

    public override void OnCollect()
    {
        base.OnCollect();
        foreach (var instantEffect in _instantEffects)
        {
            instantEffect.OnApply(Game.Instance.Player.Character);
        }
    }
}
