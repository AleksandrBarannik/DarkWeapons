using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUps_SO itemDefinition;

    private PlayerStats playerStats;
    
    
    public void UseItem()
    {
        switch (itemDefinition.itemType)
        {
            case ItemTypeDefinitions.HEALTH:
                playerStats.ChangeHealth(itemDefinition.itemAmount);
                break;

            case ItemTypeDefinitions.MANA:
                playerStats.ChangeMana(itemDefinition.itemAmount);
                break;
            
            case ItemTypeDefinitions.STAMINA:
                playerStats.ChangeStamina(itemDefinition.itemAmount);
                break;

            case ItemTypeDefinitions.WEAPON:
                //playerStats.ChangeWeapon(this);
                break;
            
            case ItemTypeDefinitions.WEALTH:
                //playerStats.GiveWealth(itemDefinition.itemAmount);
                break;
        }
    }
    
    
    //Здесь же будет передача  классу инвентарь или использование предмета




}

