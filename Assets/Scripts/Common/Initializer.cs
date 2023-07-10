using System.Collections;
using System.Collections.Generic;
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
        if (Game.Instance == null)
        {
            Instantiate(gameManagerPrefab);
        }
        StartCoroutine(SetLevel());
    }

    private IEnumerator SetLevel()
    {
         Game.Instance.Level = _currentLevel;
         Game.Instance.Player = _player;

         if (_currentLevel == null || _player == null)
         {
             Game.Instance.ScreenController.Push_T<MenuScreen>();
         }
         else
         {
             yield return null;
             Game.Instance.EventBus.OnLevelStarted();
         }
    }
    
    
}
