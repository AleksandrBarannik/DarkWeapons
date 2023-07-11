using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ОТвечает за UI панели паузы
public class PauseScreen : Screen
{
    [SerializeField] 
    private Button _unPausedButton;

    [SerializeField]
    private Button _mainMenuButton;

    private int mainMenuIndex = 0;


    private void Start()
    {
        _unPausedButton.onClick.AddListener(UnPause);
        _mainMenuButton.onClick.AddListener(BackMainMenu);
    }

    public override void OnBackPressed()
    {
        Game.Instance.UnPause();
       
    }
    
    private void UnPause()
    {
        Game.Instance.ScreenController.Top().OnBackPressed();
    }
    
    private void BackMainMenu()
    {
        SceneLoader.Instance.LoadScene(mainMenuIndex);
    }
    
}
