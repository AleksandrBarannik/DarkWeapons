using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] 
    private Slider healthBar;
    
    [SerializeField] 
    private TextMeshProUGUI healthText;
    
    [SerializeField] 
    private Slider staminaBar;
    
    [SerializeField] 
    private TextMeshProUGUI staminaText;


    [SerializeField] 
    private Stats _stats;

    private void Start()
    {
        UpdateHealth();
        UpdateStamina();
    }
    
    private void Update()
    {
        _stats.onChangeHealth.AddListener(UpdateHealth);
        _stats.onChangeStamina.AddListener(UpdateStamina);
    }

    public void UpdateHealth()
    {
        healthBar.value = _stats.CurrentHealthPoints;
        healthBar.maxValue = _stats.MaxHealth;
        
        if (healthText != null)
        {
            healthText.text= (healthBar.value).ToString();
        }

    }
    
    public void UpdateStamina()
    {
        staminaBar.value = _stats.CurrentStaminaPoints;
        staminaBar.maxValue = _stats.MaxStamina;
        if (staminaText != null)
        {
             staminaText.text= (staminaBar.value).ToString();
        }
       
       
    }
    
    
}
