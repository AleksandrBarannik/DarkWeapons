using UnityEngine;

public class PlayerStats : MagicStats
{
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

    public void ApplyStats(int additionalStrength)
    {
        strength += additionalStrength;
        skillPoints -= additionalStrength;
    }
    
    private void LevelUp()
    {
        AddSkillPoints();
        experienceToLevelUp *= 2;
        currentExperience = 0;
        level++;

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
