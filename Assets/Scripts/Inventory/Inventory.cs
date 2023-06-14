using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Сам инвентарь (не визуал , логика всего инвентаря, добавление предметов)
public class Inventory
{
    
    
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
        
        if (bag.Count >= INVENTORY_SIZE)
        {
             Debug.Log("Инвентарь забит");
             return false;
        } 
        bag.Add(item);
        
        return true;
    }

    public void Equip(EquippableItem equippableItem)
    {
        if (IsEquipped(equippableItem))
        {
            var itemInSlot = equipment[equippableItem.Slot];
            UnEquip(itemInSlot);
            
           // надо как-то экипировать нужный предмет
        }
        else
        {
            equipment.Add(equippableItem.Slot, equippableItem);
            for (int i = 0; i < bag.Count; i++ )
            {
                var equipableInBag = bag[i] as EquippableItem;
                if (equipableInBag == equippableItem)
                {
                    bag[i] = null;
                    
                    return;
                }
            }

            Debug.LogError($"Экипируемого предмета нет в инвентаре {equippableItem.Name}");
        }
    }
    public void UnEquip(EquippableItem equippableItem)
    {
        var prewiousEquip = equippableItem;
        equipment.Remove(equippableItem.Slot);
        bag.Add(prewiousEquip);
    }

    public bool IsEquipped(EquippableItem equippableItem)
    {
        if (equipment.ContainsKey(equippableItem.Slot))
        {
            return true;
        }
        return false;
    }







}
