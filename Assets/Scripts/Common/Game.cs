using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public static Game Instanse{get;private set;}
    
    private Configs _configs;
    private Level _level;
    private Player _player;

    public Level Level
    {
        get => _level;
        set => _level = value;
    }
    
    public Player Player => _player;
    

    private void Awake()
    {
        Instanse = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
