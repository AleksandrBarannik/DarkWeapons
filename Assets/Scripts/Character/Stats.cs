using System;
using UnityEngine;


public class Stats : MonoBehaviour
{
    public Action onChangeHealth;
    public Action onChangeStamina;
    
    [SerializeField]
    protected int strength = 1;
    
    [SerializeField]
    protected int agility = 1;
    
    [SerializeField]
    protected int vitality = 1;

    [SerializeField][Range(1,80)]
    protected int level = 1;


    public int currentHealthPoints;
    public int currentStaminaPoints;
    public int MaxHealth => Mathf.Max(5,strength *(5 + vitality)) ;
    public int MaxStamina => Mathf.Max(5,vitality *(5 + agility)) ;
    public float Speed => Mathf.Min(10, Mathf.Max(4, 4 + 0.1f * vitality * agility));
    public int AttackDamage => Mathf.Max(2,1 + strength);
    public float AttackSpeed => Mathf.Max(1,  1 + (0.1f * agility*strength));


    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        currentHealthPoints = MaxHealth;
        currentStaminaPoints = MaxStamina;
    }

    public void ChangeHealth(int value)
    {
        //добавить Условие для бутылки с зельем
        //CurrentHealthPoints += Value;
        
        //добавить Условие для удара по нам противником
        currentHealthPoints -= value;
        onChangeHealth?.Invoke();
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
