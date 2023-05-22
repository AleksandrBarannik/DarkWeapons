using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ОТвечает за UI панели инвентаря
public class InventoryScreen : Screen
{
    [SerializeField]
    private List<ItemInventorySlot> _bagSlots;

    [SerializeField]
    private ItemInventorySlot _slotPrefab;

    [SerializeField] 
    private Transform _slotsParent;

    private void Awake()
    {
        for (int i = 0; i <Inventory.INVENTORY_SIZE; i++)
        {
            var newSlot = Instantiate(_slotPrefab, _slotsParent);
            _bagSlots.Add(newSlot);
        }
    }

    public override void OnPush()
    {
        base.OnPush();
        for (int i = 0; i < Game.Instance.Player.Inventory.Bag.Count; i++)
        {
            _bagSlots[i].SetItem(Game.Instance.Player.Inventory.Bag[i]);
        }
    }
}
