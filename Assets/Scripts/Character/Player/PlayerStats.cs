using UnityEngine;

public class PlayerStats : MagicStats
{
    [SerializeField] 
    private int experienceToLevelUp = 100;
    
    [SerializeField]
    private int experienceToAdd = 100;
    
    [SerializeField]
    private int skillPoints = 0;

    public int currentExperience = 0;
    public int MaxExperience  => experienceToLevelUp;


    
    private void Update()
    {
        if (currentExperience == MaxExperience)
        {
            LevelUp();
        }
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
    
    public void AddExperiense() 
    {
        currentExperience += experienceToAdd;
    }
    
    
    

}
