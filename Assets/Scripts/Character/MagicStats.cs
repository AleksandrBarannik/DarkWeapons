using System;
using UnityEngine;


public class MagicStats : Stats
{
    public Action onChangeMana;
    
    [SerializeField]
    protected int intelligence;
    public int Intelligence => intelligence +effectsProxy.IntelligenceBonus;
    
    [SerializeField]
    protected int wisdom = 1;
    public int Wisdom => wisdom + effectsProxy.WisdomBonus;


    public int currentManaPoints;
    public int MaxMana => Mathf.Max(5, intelligence * (wisdom * 5));
    public float SpeedMagicCast =>Mathf.Max(1,  1 + (0.1f * intelligence * wisdom));
    public int MagicDamage => Mathf.Max(1, 1 *wisdom);
    public int MagicBulletCount => Mathf.Max(1, 3 * intelligence);

    protected override void Initialize()
    {
        base.Initialize();
        currentManaPoints = MaxMana;
    }
    
    public void ChangeMana(int value)
    {
        // добавить Условие для бутылки с зельем
        //CurrentManaPoints += Value;
        
        // добавить Условие расхода манны за заклинание
        currentManaPoints -= value;
        onChangeMana?.Invoke();
    }
}
