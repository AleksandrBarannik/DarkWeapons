using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDataBase", menuName = "DarkWeapons/ItemsDataBase", order = 1)] 
public class ItemsDataBase : ScriptableObject
{
    [SerializeField] 
    private List<EquippableItem> _equippableItems;
    public List<EquippableItem> EquippableItems => _equippableItems;
    
    [SerializeField]
    private List<InstantItem> _instantItems;
    public List<InstantItem> InstantItems => _instantItems;

    [SerializeField]
    private List<ConsumableItem> _consumableItems;
    public List<ConsumableItem> ConsumableItems => _consumableItems;
}
