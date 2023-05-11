using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Отвечает за обновления мына  для панели Главного игрока
public class PlayerPanel : CharacterPanel
{
    private PlayerStats _playerStats;
    
    [SerializeField] 
    private Slider manaBar;
    
    [SerializeField] 
    private TextMeshProUGUI manaText;
    
    protected override void Start()
    {
        _playerStats = Game.Instance.Player.PlayerStats;
        SetTarget(_playerStats);
        UpdateMana();
        _playerStats.onChangeMana += UpdateMana;
        base.Start();
    }

    //do not remove (hide parent Update)
    private void Update()
    {
        
    }


    private void UpdateMana()
    {
        manaBar.value = _playerStats.currentManaPoints;
        manaBar.maxValue = _playerStats.MaxMana;
        manaText.text= (manaBar.value).ToString();

    }
}
