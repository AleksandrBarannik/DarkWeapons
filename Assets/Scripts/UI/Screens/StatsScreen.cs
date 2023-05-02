using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : Screen
{
    [SerializeField]
    private Button _strengthUpButton;
    
    [SerializeField]
    private Button _strengthDownButton;

    private int deltaStrength = 0;

    private int _remainsSkillPoints;
    
    [SerializeField]
    private Button _applyButton;
    
    [SerializeField]
    private Button _resetButton;

    [SerializeField]
    private Text _strengthValue;
    
    [SerializeField]
    private Text _skillPointsValue;


    private void Start()
    {
        _strengthUpButton.onClick.AddListener(() => 
        {
            deltaStrength++;
            _remainsSkillPoints--;
            UpdateValues();
            UpdateButtonState();
        } );
        
        _strengthDownButton.onClick.AddListener(() => 
        {
            deltaStrength--;
            _remainsSkillPoints++;
            UpdateValues();
            UpdateButtonState();
        } );
        
        _applyButton.onClick.AddListener(() => 
        {
            Game.Instance.Player.PlayerStats.ApplyStats(deltaStrength);
            OnPush();
        } );
    }

    public override void OnPush()
    {
        base.OnPush();
        
        _remainsSkillPoints = Game.Instance.Player.PlayerStats.SkillPoints;
        deltaStrength = 0;
        UpdateValues();
        UpdateButtonState();
        
    }

    private void UpdateButtonState()
    {
        _strengthDownButton.interactable = deltaStrength > 0;
        _strengthUpButton.interactable = _remainsSkillPoints > 0;
        _applyButton.interactable = _remainsSkillPoints < Game.Instance.Player.PlayerStats.SkillPoints;
        _resetButton.interactable = _remainsSkillPoints < Game.Instance.Player.PlayerStats.SkillPoints;
    }

    private void UpdateValues()
    {
        _strengthValue.text = (Game.Instance.Player.PlayerStats.Strength + deltaStrength ).ToString();
        _skillPointsValue.text = _remainsSkillPoints.ToString();
    }
    
    
    
    
    
    
    
    
}
