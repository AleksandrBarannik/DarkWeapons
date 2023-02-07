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
                                                     Game.Instanse.Level.EnemiesController.EnemiesParent);

            spawnEnemy.transform.position = transform.position;
            
            //НОВОЕ ДОБАВИЛ:
            var spawnEnemyConrtoller = spawnEnemy.GetComponent<EnemyCharacterController>();
            //Выдать точки патруля для создаваемого обьекта
            spawnEnemyConrtoller.PatrolPath = Game.Instanse.Level.EnemiesController._patrolPath;
            spawnEnemyConrtoller.Player = Game.Instanse.Level.EnemiesController._player;
            
        }
    }
    
}
