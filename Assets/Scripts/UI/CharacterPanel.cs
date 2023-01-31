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
    
    

    private EnemyCharacterController _target;

    private void Start()
    {
        UpdateHealth();
        UpdateStamina();
        _stats.onChangeHealth += UpdateHealth;
        _stats.onChangeStamina += UpdateStamina;
    }
    
    private void Update()
    {
        var position = Camera.main.WorldToScreenPoint(_target.transform.position + Vector3.up * 2);
        position.x = position.x / Screen.width * 1280 - 640;
        position.y = position.y / Screen.height * 720 - 360;
        transform.localPosition = position;
    }

    protected void UpdateHealth()
    {
        healthBar.value = _stats.currentHealthPoints;
        healthBar.maxValue = _stats.MaxHealth;
        
        if (healthText != null)
        {
            healthText.text= (healthBar.value).ToString();
        }

    }

    protected void UpdateStamina()
    {
        staminaBar.value = _stats.currentStaminaPoints;
        staminaBar.maxValue = _stats.MaxStamina;
        if (staminaText != null)
        {
             staminaText.text= (staminaBar.value).ToString();
        }
       
       
    }

    public void SetTarget(EnemyCharacterController  target)
    {
        _target = target;
        _stats = target.GetComponent<Stats>();
    }
    
    
}
