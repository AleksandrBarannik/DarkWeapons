using System;
using UnityEngine;


public class Stats : MonoBehaviour
{
    public Action onChangeHealth;
    public Action onChangeStamina;
    public Action onCharacterDied;

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
    public int MaxHealth => Mathf.Max(5,Strength * (5 + Vitality)) ;
    public int MaxStamina => Mathf.Max(5,Vitality * (5 + Agility)) ;
    public float Speed => Mathf.Min(10, Mathf.Max(4, 4 + 0.1f * Vitality * Agility));
    public int AttackDamage => Mathf.Max(2,1 + Strength);
    public float AttackSpeed => Mathf.Max(1,  1 + (0.1f * Agility * Strength));

    public float ColdDownAttack => _nextAttackTime;

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
        //добавить Условие для бутылки с зельем
        //CurrentHealthPoints += Value;
        
        //добавить Условие для удара по нам противником
        currentHealthPoints -= value;
        onChangeHealth?.Invoke();
        if (currentHealthPoints < 0)
            onCharacterDied?.Invoke();
            
    }
    
    public void ChangeStamina(int value)
    {
        // добавить Условие для бутылки с зельем
        //CurrentStaminaPoints += Value;
        
        // добавить Условие для удара по нам противником
        currentStaminaPoints -= value;
        onChangeStamina?.Invoke();
    }

}
