using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeDefinitions { HEALTH, STAMINA, MANA, WEALTH, WEAPON, BUFF, EMPTY };


[CreateAssetMenu(fileName = "NewItem", menuName = "DarkWeapons/New ItemConfig", order = 1)] 
public class ItemPickUps_SO : ScriptableObject
{

    public string itemName = "NewItem";
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.EMPTY;

    
    [Tooltip("Ссылка на сам предмет")]public Item item;
    

    [Tooltip("Значение передаваемое системы характеристик")]
    public int itemAmount = 0;

    
    [Tooltip("изображение отображающееся в инвентаре ")]
    public Sprite itemIcon = null;

    
    
    [Tooltip("Был ли экипирован предмет")] public bool isEquipped = false;

    [Tooltip("Можно ли использовать предмет")]
    public bool isInteractable = false;

    [Tooltip("Применен сразу или помещен в инвентарь")]
    public bool isStorable = false;

    [Tooltip("Разрушаемый или нет")] public bool isIndestructable = false;
    [Tooltip("Групируемый или нет")] public bool isStackable = false;

    [Tooltip("При использовали и предмет изчез или нет")]
    public bool destroyOnUse = false;


    [Tooltip("вес предмета")] public float itemWeight = 0f;




}
