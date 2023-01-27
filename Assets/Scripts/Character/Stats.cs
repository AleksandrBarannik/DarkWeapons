using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public UnityEvent onChangeHealth;
    public UnityEvent onChangeStamina;
    
    [SerializeField]
    protected int strength = 1;
    
    [SerializeField]
    protected int agility = 1;
    
    [SerializeField]
    protected int vitality = 1;

    [SerializeField][Range(1,80)]
    protected int level = 1;


    public int CurrentHealthPoints;
    public int CurrentStaminaPoints;
    public int MaxHealth => Mathf.Max(5,strength *(5 + vitality)) ;
    public int MaxStamina => Mathf.Max(5,vitality *(5 + agility)) ;
    public float Speed => Mathf.Min(10, Mathf.Max(4, 4 + 0.1f * vitality * agility));
    public int AttackDamage => Mathf.Max(2,1 + strength);
    public float AttackSpeed => Mathf.Max(1,  1 + (0.1f * agility*strength));


    private void Start()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        CurrentHealthPoints = MaxHealth;
        CurrentStaminaPoints = MaxStamina;
    }

    public void ChangeHealth(int Value)
    {
        //добавить Условие для бутылки с зельем
        //CurrentHealthPoints += Value;
        
        //добавить Условие для удара по нам противником
        CurrentHealthPoints -= Value;
        onChangeHealth.Invoke();
    }
    
    public void ChangeStamina(int Value)
    {
        // добавить Условие для бутылки с зельем
        //CurrentStaminaPoints += Value;
        
        // добавить Условие для удара по нам противником
        CurrentStaminaPoints -= Value;
        onChangeStamina.Invoke();
    }

}
