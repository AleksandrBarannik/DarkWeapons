using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Спавнер врагов (создает самих врагов)
public class EnemySpawner : ActivatableObject
{
    [SerializeField]
    private EnemySpawnConfig _spawnConfig;
    
    public override void Activate()
    {
        StartCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
    {
        foreach (var spawnNode in _spawnConfig.spawnNodes)
        {
            yield return new WaitForSeconds(spawnNode.delayBeforeSpawn);
            
            
            var spawnEnemy = Instantiate(spawnNode.enemyToSpawn,
                                                     Game.Instance.Level.EnemiesController.EnemiesParent);

            spawnEnemy.transform.position = transform.position;
            spawnEnemy.PatrolPath = Game.Instance.Level.EnemiesController._patrolPath;
            spawnEnemy.Player = Game.Instance.Level.EnemiesController._player;
            
            Game.Instance.EventBus.OnEnemySpawn(spawnEnemy);
            
        }
    }
    
}
