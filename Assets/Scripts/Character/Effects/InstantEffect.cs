using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Мгновенные эффекты (применяются сразу при взятии предмета и не хранятся в инвентаре)
[CreateAssetMenu(fileName = "New InstantEffect",menuName = "DarkWeapons/Effects/InstantEffect")]
public class InstantEffect : Effect
{
    [SerializeField]
    protected int restoreHealth;
    public int RestoreHealth => restoreHealth;

    [SerializeField]
    protected int restoreMana;
    public int RestoreMana => restoreMana;
    
    [SerializeField]
    protected int restoreStamina;
    public int RestoreStamina => restoreStamina;

    [SerializeField]
    protected int addMoney;
    public int AddMoney => addMoney;

    [SerializeField]
    protected int addExperience;
    public int AddExperience => addExperience;

    public override void OnApply(BasicCharacter basicCharacter)
    {
        base.OnApply(basicCharacter);
        var playerStats = basicCharacter.Stats as PlayerStats;
        playerStats.ChangeHealth(restoreHealth);
        playerStats.ChangeMana(restoreMana);
        playerStats.ChangeStamina(restoreStamina);
        playerStats.AddExperience(addExperience);
        Game.Instance.Player.AddMoney(addMoney);

    }

    public  override Effect Copy()
    {
        var effect = new InstantEffect();
        effect.restoreHealth = this.restoreHealth;
        effect.restoreMana = this.restoreMana;
        effect.restoreStamina= this.restoreStamina;
        effect.addMoney = this.addMoney;
        effect.addExperience = this.addExperience;
        
        return effect;
    }
}
