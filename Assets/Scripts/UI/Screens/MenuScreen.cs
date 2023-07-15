using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : Screen
{
    [SerializeField]
    private Button _buttonExit;
    
    [SerializeField]
    private Button _buttonContinue;
    
    [SerializeField]
    private Button _buttonStart;

    private int newGameIndex = 1;

    private void Start()
    {
        _buttonStart.onClick.AddListener(LoadNewGame);
        _buttonExit.onClick.AddListener(ExitGame);
        _buttonContinue.onClick.AddListener(ContinueGame);
        Debug.Log("Menu Initialized");
    }


    private void LoadNewGame()
    {
        gameObject.SetActive(false);
        SceneLoader.Instance.slider.gameObject.SetActive(true);
        SceneLoader.Instance.LoadScene(newGameIndex);
       
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    
    private void ContinueGame()
    {
        //Здесь идет загрузка сохраненой сессии
    }
}
