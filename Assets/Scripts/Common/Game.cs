using UnityEngine;
    
public class Game : MonoBehaviour//Содержит все об модулях(системах) в игре
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
