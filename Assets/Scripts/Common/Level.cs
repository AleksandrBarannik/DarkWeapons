using UnityEngine;


public class Level : MonoBehaviour //Соддержит все обьекты на уровне (ссылки на текузий уровеньБ,главного перрсонажа, ссылки на всех врагов)
{
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private PlayerCharacterController mainCharacter;
    [SerializeField] private LevelEnemiesController _levelEnemiesController;
    public LevelEnemiesController EnemiesController => _levelEnemiesController;
}
    
