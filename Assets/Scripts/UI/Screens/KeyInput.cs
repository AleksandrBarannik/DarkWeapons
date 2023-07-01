using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Отвечает за нажаты клавиши
public class KeyInput : MonoBehaviour
{
    [SerializeField]
    private Button _buttonInventory;
    
    [SerializeField]
    private Button _buttonPlayerStats;
    
    [SerializeField]
    private Button _buttonEscape;
    
    #region PC Version
    void Update()
    {
        //InputControlKey();
        
    }

    private void InputControlKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UseEscape();
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            UsePlayerStatsPanel();
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            UseInventory();
        }
    }  
    
    #endregion


    #region Mobile Version
    private void Start()
    {
        _buttonInventory.onClick.AddListener(UseInventory);
        _buttonPlayerStats.onClick.AddListener(UsePlayerStatsPanel);
        _buttonEscape.onClick.AddListener(UseEscape);
    }
    

    private void UseInventory()
    {
        if (Game.Instance.ScreenController.Top() is InventoryScreen)
            Game.Instance.ScreenController.Pop();
        else
            Game.Instance.ScreenController.Push_T<InventoryScreen>();
        
    }

    private void UsePlayerStatsPanel()
    {
        if (Game.Instance.ScreenController.Top() is StatsScreen)
            Game.Instance.ScreenController.Pop();
        else
            Game.Instance.ScreenController.Push_T<StatsScreen>();

    }

    private void UseEscape()
    {
        Game.Instance.ScreenController.Top().OnBackPressed();
    }
    
    #endregion
}
