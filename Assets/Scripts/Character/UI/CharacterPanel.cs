using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] 
    private Slider healthBar;
    
    [SerializeField] 
    private Slider manaBar;
    
    [SerializeField] 
    private Slider staminaBar;
    
    [SerializeField] 
    private Stats _stats;

    private void Start()
    {
        _stats.onDecreaseHealth.AddListener(UpdateUI);
        _stats.onIncreaseHealth.AddListener(UpdateUI);
    }

    private void UpdateUI()
    {
        healthBar.maxValue = _stats.MaxHealth;
        healthBar.value = _stats.CurrentHealthPoints;

    }
}
