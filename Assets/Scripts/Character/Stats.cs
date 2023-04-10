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
    protected int agility = 1;
    
    [SerializeField]
    protected int vitality = 1;

    [SerializeField][Range(1,80)]
    protected int level = 1;

    [SerializeField] 
    private float _nextAttackTime= 10f;

    [SerializeField] 
    private int _rangeAttack = 2;
    
    


    public int currentHealthPoints;
    public int currentStaminaPoints;
    public int MaxHealth => Mathf.Max(5,Strength *(5 + vitality)) ;
    public int MaxStamina => Mathf.Max(5,vitality *(5 + agility)) ;
    public float Speed => Mathf.Min(10, Mathf.Max(4, 4 + 0.1f * vitality * agility));
    public int AttackDamage => Mathf.Max(2,1 + Strength);
    public float AttackSpeed => Mathf.Max(1,  1 + (0.1f * agility*Strength));

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
