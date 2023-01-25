using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] 
    private Slider healthBar;
    
    [SerializeField] 
    private Slider manaBar;
    
    [SerializeField] 
    private Slider staminaBar;
    
    [SerializeField] 
    private PlayerCharacterController player;

    private void Start()
    {
       player.CharacterStats.onDecreaseHealth.AddListener(UpdateUI);
       player.CharacterStats.onIncreaseHealth.AddListener(UpdateUI);
    }

    private void UpdateUI()
    {
        healthBar.maxValue = player.CharacterStats.MaxHealth;
        healthBar.value = player.CharacterStats.CurrentHealthPoints;

    }
}
