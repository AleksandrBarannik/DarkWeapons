using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MagicStats
{
    [SerializeField] 
    private int _experienceToLevelUp = 100;
    
    [SerializeField]
    private int experiensToAdd = 100;
    
    [SerializeField]
    private int _skillPoints = 0;

    public int CurrentExperience = 0;
    private object Range;
    public int MaxExperience  =>_experienceToLevelUp;


    private void Update()
    {
        if (CurrentExperience == MaxExperience)
        {
            LevelUp();
        }
    }


    private void LevelUp()
    {
        AddSkillPoints();
        _experienceToLevelUp *= 2;
        CurrentExperience = 0;
        level++;

    }

    private void AddSkillPoints()
    {
        if (level >= 50 )
        {
            _skillPoints++;;
        }
        else
        {
            _skillPoints += 3;
        }
    }
    
    public void AddExperiense() 
    {
        CurrentExperience += experiensToAdd;
    }
    
    
    

}
