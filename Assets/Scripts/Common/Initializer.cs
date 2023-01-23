using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField]
    private Game _gameManagerPrefab;

    [SerializeField] private Level CurrentLevel;
    private void Start()
    {
        Instantiate(_gameManagerPrefab);
       LevelCreator();
    }

    private void LevelCreator()
    {
         Game.Instanse.Level = CurrentLevel;
    }
    
    
}
