using System;
using UnityEngine;


public class Stats : MonoBehaviour
{
    public Action onChangeHealth;
    public Action onChangeStamina;
    public Action onCharacterDied;

    [SerializeField]
    private int _rewardExperience;
    public int RewardExperience => _rewardExperience;

    public bool IsDead => (currentHealthPoints <=0);

    [SerializeField]
    protected EffectsProxy effectsProxy;
    public EffectsProxy EffectsProxy => effectsProxy;

    [SerializeField]
    protected int strength = 1;
    public int Strength => strength + effectsProxy.StrengthBonus;

    [SerializeField] 
    protected int agility;
    public int Agility => agility + effectsProxy.AgilityBonus;

    [SerializeField] 
    protected int vitality;
    public int Vitality => vitality + effectsProxy.VitalityBonus;


    [SerializeField][Range(1,80)]
    protected int level = 1;

    [SerializeField] 
    private float _nextAttackTime= 10f;

    [SerializeField] 
    private int _rangeAttack = 2;
    
    


    public int currentHealthPoints;
    public int currentStaminaPoints;
    public int MaxHealth => Mathf.Max(5,Strength * (5 + Vitality)) + effectsProxy.HealthBonus;
    public int MaxStamina => Mathf.Max(5,Vitality * (5 + Agility))+ effectsProxy.StaminaBonus;
    public float Speed => Mathf.Min(10, Mathf.Max(4, 4 + 0.1f * Vitality * Agility));
    
    public int AttackDamage => Mathf.Max(2,1 + Strength);
    public float AttackSpeed => Mathf.Max(1,  1 + (0.1f * Agility * Strength)); //добавить влияние на перезарядку атаки

    public float ColdDownAttack => _nextAttackTime;//проконсультироваться с андреем

    public int RangeAttack => _rangeAttack;


    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        currentHealthPoints = MaxHealth;
        currentStaminaPoints = MaxStamina;

        if (effectsProxy == null)
        {
            effectsProxy = this.gameObject.AddComponent<EffectsProxy>();
        }
    }

    public void ChangeHealth(int value)
    {
        
        currentHealthPoints = (int) Math.Clamp(currentHealthPoints + value ,0,MaxHealth);
        onChangeHealth?.Invoke();
        if (currentHealthPoints < 0)
        {
            Game.Instance.Player.PlayerStats.AddExperience(_rewardExperience);
            onCharacterDied?.Invoke();
        }
            
            
    }
    
    public void ChangeStamina(int value)
    {
        currentStaminaPoints = Math.Clamp(currentStaminaPoints + value,0,MaxStamina);
        onChangeStamina?.Invoke();
        if (currentStaminaPoints <= 0)
        {
            // подождать какое-то время на востановление стамины
        }
            
    }

}
