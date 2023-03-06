using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Спавнер врагов (создает самих врагов)
public class EnemySpawner : ActivatableObject
{
    [SerializeField]
    private EnemySpawnConfig _spawnConfig;

    private List<EnemyCharacterController> spawnedEnemyList = new List<EnemyCharacterController>();

    public bool AllEnemiesSpawned { get; private set; } = false;
    
    
    public override void Activate()
    {
        StartCoroutine(SpawnProcess());
    }

    public int SpawnedAliveEnemyCount()
    {
        int count = 0;
        foreach (var enemy in spawnedEnemyList)
        {
            if (enemy != null && !enemy.ControllerTarget.Stats.IsDead)
                count++;
        }
        return count;
    }
    

    private IEnumerator SpawnProcess()
    {
        foreach (var spawnNode in _spawnConfig.spawnNodes)
        {
            yield return new WaitForSeconds(spawnNode.delayBeforeSpawn);
            
            
            var spawnEnemy = Instantiate(spawnNode.enemyToSpawn,
                                                     Game.Instance.Level.EnemiesController.EnemiesParent);

            spawnEnemy.transform.position = transform.position;
            
            //назначает точки патруля  и назначает  кого преследовать (главного героя)
            spawnEnemy.PatrolPath = Game.Instance.Level.EnemiesController._patrolPath;
            spawnEnemy.Player = Game.Instance.Level.EnemiesController._player;
            
            Game.Instance.Level.EnemiesController.Enemies.Add(spawnEnemy);
            Game.Instance.EventBus.OnEnemySpawn(spawnEnemy);
            spawnedEnemyList.Add(spawnEnemy);
            
        }

        AllEnemiesSpawned = true;
    }
    
}
