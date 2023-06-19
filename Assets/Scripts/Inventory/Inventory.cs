using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Сам инвентарь (не визуал , логика всего инвентаря, добавление предметов)
public class Inventory
{
    public event Action OnUpdateInventory;
    
    
    public const int INVENTORY_SIZE = 40;
    private List<Item> bag = new List<Item>();
    public List<Item> Bag => bag;
    
    private Dictionary<EquipmentSlot,EquippableItem> equipment = new Dictionary<EquipmentSlot, EquippableItem>();

    public Dictionary<EquipmentSlot, EquippableItem> Equipment => equipment;

    public bool Add(Item item)
    {
        
        //ДОбавляет стаковые предметы в инвентарь
        for (int i = 0; i < bag.Count; i++)
        {
            if (bag[i] == null)
                continue;
            
            if (item.ID == bag[i].ID)
            {
                var sanityCheck = 0;
                while (bag[i].StackCount < bag[i].StackMaxCount && sanityCheck < 1000)
                {
                    sanityCheck++;
                    bag[i].StackCount++;
                    item.StackCount--;

                    if (item.StackCount == 0)
                        return true;
                }
                if (sanityCheck >= 1000)
                    throw  new Exception("Infinity Loop");
            }
            
        }
        
        for (int i = 0; i < bag.Count; i++)
        {
            if (bag[i] == null)
            {
                bag[i] = item;
                UpdateInventory();
                return true;
            }
        }
        
        
        if (bag.Count >= INVENTORY_SIZE)
        {
             Debug.Log("Инвентарь забит");
             return false;
        } 
        bag.Add(item);
        
        UpdateInventory();
        return true;
        
    }

    public void Equip(EquippableItem equippableItem)
    {
        Item previousEquipped = null;
        if (HaveSomethingInSlot(equippableItem))
        {
            previousEquipped = equipment[equippableItem.Slot];
        }

        equipment[equippableItem.Slot] = equippableItem;
        for (int i = 0; i < bag.Count; i++)
        {
            var equipableInBag = bag[i] as EquippableItem;
            if (equipableInBag == equippableItem)
            {
                bag[i] = previousEquipped;
                UpdateInventory();
                return;
            }
        }

        Debug.LogError($"Экипируемого предмета нет в инвентаре {equippableItem.Name}");

        UpdateInventory();
    }

    public void UnEquip(EquippableItem equippableItem)
    {
        var prewiousEquip = equippableItem;
        equipment.Remove(equippableItem.Slot);
        Add(prewiousEquip);
        UpdateInventory();
    }

    public bool HaveSomethingInSlot(EquippableItem equippableItem)
    {
        if (equipment.ContainsKey(equippableItem.Slot))
        {
            return equipment[equippableItem.Slot] != null;
        }
        return false;
    }
    public bool IsEquipped(EquippableItem equippableItem)
    {
        if (equipment.ContainsKey(equippableItem.Slot))
        {
            return equipment[equippableItem.Slot] == equippableItem;
        }
        return false;
    }

    public void Remove(Item item)
    {
        for (var i = 0; i < bag.Count; i++)
        {
            if (bag[i] == item)
            {
                bag[i] = null;
                return;
            }
        }
    }

    public void UpdateInventory()
    {
        OnUpdateInventory?.Invoke();
    }







}
