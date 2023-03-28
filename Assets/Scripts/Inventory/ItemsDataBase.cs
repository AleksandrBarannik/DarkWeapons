using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDataBase", menuName = "DarkWeapons/ItemsDataBase", order = 1)] 
public class ItemsDataBase : ScriptableObject
{
    [SerializeField] private List<EquippableItem> _equippableItems;
    [SerializeField] private List<InstantItem> _instantItems;
    [SerializeField] private List<ConsumableItem> _consumableItems;
    
}
