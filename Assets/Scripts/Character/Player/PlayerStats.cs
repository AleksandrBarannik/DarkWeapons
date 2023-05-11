using UnityEngine;


//Отвечает за характеристики главного персонажа (повышение уровня)
public class PlayerStats : MagicStats
{
    [SerializeField]
    private int _countActiveStats = 4;
    
    [SerializeField] 
    private int experienceToLevelUp = 100;
    public int MaxExperience  => experienceToLevelUp;
    
    [SerializeField]
    private int skillPoints = 0;

    public int SkillPoints => skillPoints;
    

    private int currentExperience = 0;
    
    
    private void Update()
    {
        if (currentExperience == MaxExperience)
        {
            LevelUp();
        }
    }

    public void ApplyStats(int additionalStrength,int additionalAgility,
                            int additionalIntelligence, int additionalVitality )
    {
        strength += additionalStrength;
        agility += additionalAgility;
        intelligence += additionalIntelligence;
        vitality += additionalVitality;
        skillPoints -= additionalStrength + additionalAgility + additionalIntelligence + additionalVitality;
        
    }

    public void ResetStats()
    {
        skillPoints = (strength + agility + intelligence + vitality) - _countActiveStats;
        strength = 1; 
        agility = 1;
        intelligence = 1; 
        vitality = 1;
    }
    
    
    private void LevelUp()
    {
        AddSkillPoints();
        experienceToLevelUp *= 2;
        currentExperience = 0;
        level++;
        currentHealthPoints = MaxHealth;
        currentStaminaPoints = MaxStamina;
        currentManaPoints = MaxMana;

    }

    private void AddSkillPoints()
    {
        if (level >= 50 )
        {
            skillPoints++;;
        }
        else
        {
            skillPoints += 3;
        }
    }
    
    public void AddExperience(int ExperienceToAdd) 
    {
        currentExperience += ExperienceToAdd + effectsProxy.ExperienceBonus;
        var sanityCheck = 0;
        while (currentExperience > experienceToLevelUp && sanityCheck < 10000)
        {
            LevelUp();
            sanityCheck++;
        }
    }
    
    
    

}
