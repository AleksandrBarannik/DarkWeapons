using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Inventory
{
    public const int INVENTORY_SIZE = 40;
    private List<Item> bag = new List<Item>();
    public List<Item> Bag => bag;
    
    private Dictionary<EquipmentSlot,Item> equipment = new Dictionary<EquipmentSlot, Item>();

    public bool Add(Item item)
    {
        if (bag.Count >= INVENTORY_SIZE)
        {
             Debug.Log("Инвентарь забит");
             return false;
        }
        bag.Add(item);
        return true;
    }
}
