using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Сам инвентарь (не визуал , логика всего инвентаря, добавление предметов)
public class Inventory
{
    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = 0.2f;
    
    public const int INVENTORY_SIZE = 40;
    private List<Item> bag = new List<Item>();
    public List<Item> Bag => bag;
    
    private Dictionary<EquipmentSlot,Item> equipment = new Dictionary<EquipmentSlot, Item>();

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

    
    public void ApplyItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var timeSinceLastCLick = Time.time - lastClickTime;

            if (timeSinceLastCLick < DOUBLE_CLICK_TIME)
            {
                Debug.Log("DoubleClick");
                for (int i = 0; i < bag.Count; i++)
                {
                    bag[i].OnInteract();
                }
            }
            lastClickTime = Time.time;
        }
        
        
        
        
    }

    

    
}
