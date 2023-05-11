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
    
    [SerializeField]
    private Text _strengthValue;
    
    private int deltaStrength = 0;
    
    [SerializeField]
    private Button _agilityUpButton;
    
    [SerializeField]
    private Button _agilityDownButton;
    
    [SerializeField]
    private Text _agilityValue;
    
    private int deltaAgility = 0;

    [SerializeField] 
    private Button _intelligenceUpButton;
    
    [SerializeField] 
    private Button _intelligenceDownButton;
    
    [SerializeField]
    private Text _intelligenceValue;
    
    private int deltaIntelligence = 0;

    [SerializeField]
    private Button _vitalityUpButton;
    
    [SerializeField]
    private Button _vitalityDownButton;
    
    [SerializeField]
    private Text _vitalityValue;
    
    private int deltaVitality = 0;
    
    
    [SerializeField]
    private Button _applyButton;
    
    [SerializeField]
    private Button _resetButton;

    [SerializeField]
    private Text _skillPointsValue;
    
    private int _remainsSkillPoints;

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
        
        _agilityUpButton.onClick.AddListener(() =>
        {
            deltaAgility++;
            _remainsSkillPoints--;
            UpdateValues();
            UpdateButtonState();
        });
        
        _agilityDownButton.onClick.AddListener(() =>
        {
            deltaAgility--;
            _remainsSkillPoints++;
            UpdateValues();
            UpdateButtonState();
        });
        
        _intelligenceUpButton.onClick.AddListener(() =>
        {
            deltaIntelligence++;
            _remainsSkillPoints--;
            UpdateValues();
            UpdateButtonState();
        });
        
        _intelligenceDownButton.onClick.AddListener(() =>
        {
            deltaIntelligence--;
            _remainsSkillPoints++;
            UpdateValues();
            UpdateButtonState();
        });
        
        _vitalityUpButton.onClick.AddListener(() =>
        {
            deltaVitality++;
            _remainsSkillPoints--;
            UpdateValues();
            UpdateButtonState();
        });
        
        _vitalityDownButton.onClick.AddListener(() =>
        {
            deltaVitality--;
            _remainsSkillPoints++;
            UpdateValues();
            UpdateButtonState();
        });
        
        _applyButton.onClick.AddListener(() => 
        {
            Game.Instance.Player.PlayerStats.ApplyStats(deltaStrength, deltaAgility, deltaIntelligence, deltaVitality);
            OnPush();
        } );
        
        _resetButton.onClick.AddListener(() => 
        {
            Game.Instance.Player.PlayerStats.ResetStats();
            OnPush();
        } );
    }

    public override void OnPush()
    {
        base.OnPush();
        _remainsSkillPoints = Game.Instance.Player.PlayerStats.SkillPoints;
        deltaStrength = 0;
        deltaAgility = 0;
        deltaIntelligence = 0;
        deltaVitality = 0;
        UpdateValues();
        UpdateButtonState();
        
    }

    private void UpdateButtonState()
    {
        _strengthDownButton.interactable = deltaStrength > 0;
        _strengthUpButton.interactable = _remainsSkillPoints > 0;
        
        _agilityDownButton.interactable = deltaAgility > 0;
        _agilityUpButton.interactable = _remainsSkillPoints > 0;

        _intelligenceDownButton.interactable = deltaIntelligence > 0;
        _intelligenceUpButton.interactable = _remainsSkillPoints > 0;

        _vitalityDownButton.interactable = deltaVitality > 0;
        _vitalityUpButton.interactable = _remainsSkillPoints > 0;
        
        _applyButton.interactable = _remainsSkillPoints < Game.Instance.Player.PlayerStats.SkillPoints;
        
    }

    private void UpdateValues()
    {
        _strengthValue.text = (Game.Instance.Player.PlayerStats.Strength + deltaStrength).ToString();
        _agilityValue.text = (Game.Instance.Player.PlayerStats.Agility + deltaAgility).ToString();
        _intelligenceValue.text = (Game.Instance.Player.PlayerStats.Intelligence + deltaIntelligence).ToString();
        _vitalityValue.text = (Game.Instance.Player.PlayerStats.Vitality + deltaVitality).ToString();
        _skillPointsValue.text = _remainsSkillPoints.ToString();
    }
    
    
    
    
    
    
    
    
}
