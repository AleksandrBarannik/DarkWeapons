using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField]
    private Game gameManagerPrefab;

    [SerializeField]
    private Level _currentLevel;
    private void Awake()
    {
        Instantiate(gameManagerPrefab);
        LevelCreator();
    }

    private void LevelCreator()
    {
         Game.Instanse.Level = _currentLevel;
    }
    
    
}
