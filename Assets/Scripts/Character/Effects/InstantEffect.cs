using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New InstantEffect",menuName = "DarkWeapons/Effects/InstantEffect")]
public class InstantEffect : Effect
{
    [SerializeField]
    private int restoreHealth;
    public int RestoreHealth => restoreHealth;

    [SerializeField]
    private int restoreMana;
    public int RestoreMana => restoreMana;
    
    [SerializeField]
    private int restoreStamina;
    public int RestoreStamina => restoreStamina;

    [SerializeField]
    private int addMoney;
    public int AddMoney => addMoney;

    [SerializeField]
    private int addExperience;
    public int AddExperience => addExperience;

    public override void OnApply(BasicCharacter basicCharacter)
    {
        base.OnApply(basicCharacter);
        var playerStats = basicCharacter.Stats as PlayerStats;
        playerStats.ChangeHealth(restoreHealth);
        playerStats.ChangeMana(restoreMana);
        playerStats.ChangeStamina(restoreStamina);
        playerStats.AddExperiense(addExperience);
        Game.Instance.Player.AddMoney(addMoney);

    }
}
