using UnityEngine;
    
public class Game : MonoBehaviour//Содержит все об модулях(системах) в игре
{
    public static Game Instance{get;private set;}
    
    private EventBus _eventBus = new EventBus();

    public EventBus EventBus => _eventBus;

    public bool Paused => Time.timeScale < 0.05;


    [SerializeField]
    private ScreenController _screenController;
    public ScreenController ScreenController => _screenController;

    [SerializeField]
    private Configs _configs;
    
    private Level _level;
    
    [SerializeField]
    private Player _player;

    public Level Level
    {
        get => _level;
        set => _level = value;
    }
    
    public Player Player
    {
        get => _player;
        set => _player = value;
    }
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Pause()
    {
        _screenController.Push_T<PauseScreen>();
        Time.timeScale = 0.001f;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        _screenController.Pop();
    }
}
