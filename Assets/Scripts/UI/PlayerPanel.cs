using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : CharacterPanel
{
    [SerializeField] 
    private MagicStats _magicStats;
    
    [SerializeField] 
    private Slider manaBar;
    
    [SerializeField] 
    private TextMeshProUGUI manaText;
    
    protected override void Start()
    {
        UpdateMana();
        _magicStats.onChangeMana += UpdateMana;
        base.Start();
    }

    private void Update()
    {
        
    }


    private void UpdateMana()
    {
        manaBar.value = _magicStats.currentManaPoints;
        manaBar.maxValue = _magicStats.MaxMana;
        manaText.text= (manaBar.value).ToString();

    }
}
