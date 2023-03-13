using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Спавнер врагов (создает самих врагов)
public class EnemySpawner : ActivatableObject
{
    [SerializeField]
    private EnemySpawnConfig _spawnConfig;

    [SerializeField]
    private List<PatrolPath> _patrolPaths;

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
                                                    transform.position,Quaternion.identity);

            
            spawnEnemy.transform.parent = Game.Instance.Level.EnemiesController.EnemiesParent;
            
            //назначает точки патруля  и назначает  кого преследовать (главного героя)
            spawnEnemy.PatrolPath = _patrolPaths[Random.Range(0, _patrolPaths.Count)];
            spawnEnemy.Player = Game.Instance.Level.MainCharacter.gameObject;
            
            Game.Instance.Level.EnemiesController.Enemies.Add(spawnEnemy);
            Game.Instance.EventBus.OnEnemySpawn(spawnEnemy);
            spawnedEnemyList.Add(spawnEnemy);
            
        }

        AllEnemiesSpawned = true;
    }
    
}
