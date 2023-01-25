using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public UnityEvent onIncreaseHealth;
    public UnityEvent onDecreaseHealth;
    
    [SerializeField]
    protected int strength = 1;
    
    [SerializeField]
    protected int agility = 1;
    
    [SerializeField]
    protected int vitality = 1;

    [SerializeField][Range(1,80)]
    protected int level = 1;


    public int CurrentHealthPoints;
    public int MaxHealth => Mathf.Max(5,strength *(5 + vitality)) ;
    public int Stamina => Mathf.Max(5,vitality *(5 + agility)) ;
    public float Speed => Mathf.Min(10, Mathf.Max(4, 4 + 0.1f * vitality * agility));
    public int AttackDamage => Mathf.Max(2,1 + strength);
    public float AttackSpeed => Mathf.Max(1,  1 + (0.1f * agility*strength));


    public virtual void Initialize()
    {
        CurrentHealthPoints = MaxHealth;
    }

    public void IncreaseHealth(int Value)
    {
        CurrentHealthPoints += Value;
        onIncreaseHealth.Invoke();
    }
    
    public void DecreaseHealth(int Value)
    {
        CurrentHealthPoints -= Value;
        onIncreaseHealth.Invoke();
        if (CurrentHealthPoints <= 0)
        {
            //Dead ;
        }
    }

}
