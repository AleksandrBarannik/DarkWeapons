using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ОТвечает за UI панели инвентаря
public class InventoryScreen : Screen
{
    [SerializeField]
    private List<EquippableSlotNode> _equippableSlotNodes;
    
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

        Game.Instance.Player.Inventory.OnUpdateInventory += UpdateInventoryView;
    }

    public override void OnPush()
    {
        base.OnPush();
        UpdateInventoryView();
        
    }

    private void UpdateInventoryView()
    {
        for (int i = 0; i < Game.Instance.Player.Inventory.Bag.Count; i++)
        {
            _bagSlots[i].SetItem(Game.Instance.Player.Inventory.Bag[i]);

        }

        //Отвечает за слот экипируемый (перенос в него item)
        foreach (var equipableSlot in _equippableSlotNodes)
        {
            if (Game.Instance.Player.Inventory.Equipment.ContainsKey(equipableSlot.slot))
                equipableSlot.slotView.SetItem(Game.Instance.Player.Inventory.Equipment[equipableSlot.slot]);
            else
            {
                equipableSlot.slotView.SetItem(null);
            }
        }
    }
}



[Serializable]
public class EquippableSlotNode
{
    public EquipmentSlot slot;
    public ItemInventorySlot slotView;
}