using System.Collections.Generic;
using UnityEngine;

public class HUDScreen : MonoBehaviour
{
    [SerializeField]
    private CharacterPanel _enemyPanelPrefab;
    
    [SerializeField]
    private Transform _enemyParentPanel;

    private List<CharacterPanel> _characterPanels = new List<CharacterPanel>();

    private void Start()
    {
        foreach (var enemy in Game.Instance.Level.EnemiesController.Enemies)
        {
            CreateEnemyPanel(enemy);
        }
        Game.Instance.EventBus.onEnemySpawn += CreateEnemyPanel;
    }

    private void CreateEnemyPanel(EnemyCharacterController enemyCharacterController)
    {
        var newPanel = Instantiate(_enemyPanelPrefab, _enemyParentPanel);
        _characterPanels.Add(newPanel);
        newPanel.SetTarget(enemyCharacterController);
    }
    
    
}
