using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField]
    private Game gameManagerPrefab;

    [SerializeField]
    private Level _currentLevel;

    [SerializeField] private Player _player;
    private void Awake()
    {
        Instantiate(gameManagerPrefab);
        LevelCreator();
    }

    private void LevelCreator()
    {
         Game.Instance.Level = _currentLevel;
         Game.Instance.Player = _player;
    }
    
    
}
