using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
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

}
