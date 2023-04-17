using System;
using UnityEngine;

public class MagicStats : Stats
{
    public Action onChangeMana;
    
    [SerializeField]
    protected int intelligence;
    public int Intelligence => intelligence + effectsProxy.IntelligenceBonus;
    
    [SerializeField]
    protected int wisdom = 1;
    public int Wisdom => wisdom + effectsProxy.WisdomBonus;

    [SerializeField]
    private float _nextMagicAttackTime = 10f;


    public int currentManaPoints;
    public int MaxMana => Mathf.Max(5, intelligence * (wisdom * 5)) + EffectsProxy.ManaBonus;
    public int MagicDamage => Mathf.Max(1, 1 *wisdom);
    public int MagicBulletCount => Mathf.Max(1, 3 * intelligence);
    
    public float SpeedMagicCast =>Mathf.Max(1,  1 + (0.1f * intelligence * wisdom));
    
    public float ColdDownMagicAttack => _nextMagicAttackTime;
   
   

    protected override void Initialize()
    {
        base.Initialize();
        currentManaPoints = MaxMana;
    }
    
    public void ChangeMana(int value)
    {
        currentManaPoints = Math.Clamp(currentManaPoints + value,0,MaxMana);
        onChangeMana?.Invoke();
        if (currentManaPoints <= 0)
        {
            //подождать время  пока не востановится мана нужное количество
        }
    }
}
