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
    
    private void Start()
    {
        UpdateMana();
        UpdateHealth();
        UpdateStamina();
    }
    
    private void Update()
    {
        _magicStats.onChangeMana.AddListener(UpdateMana);
    }

    private void UpdateMana()
    {
        manaBar.value = _magicStats.CurrentManaPoints;
        manaBar.maxValue = _magicStats.MaxMana;
        manaText.text= (manaBar.value).ToString();

    }
}
