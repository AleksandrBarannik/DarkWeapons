using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnMoneyChange;

    [SerializeField]
    private PlayerStats _playerStats;
    public PlayerStats PlayerStats => _playerStats;
    
    [SerializeField]
    private BasicCharacter _Character;
    public BasicCharacter Character => _Character;
    
    [SerializeField]
    private PlayerCharacterController _player;

    private Inventory _inventory = new Inventory();

    public Inventory Inventory => _inventory;


    public ItemsFactory itemsFactory;

    private int _money;
    public int Money => _money;
    
    


    public void AddMoney(int count)
    {
        _money += count;
        OnMoneyChange?.Invoke();
        
    }

    //для траты денег у торговцев
    public bool SpentMoney(int count)
    {
        if (_money >= count)
        {
            _money -= count;
            OnMoneyChange?.Invoke();
            return true;
        }
        return false;
    }
}
