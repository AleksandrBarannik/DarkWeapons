using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ОТвечает за активацию боя на арене и запуск спавнеров  противников и блокировку дверей во время боя
public class ArenaFightActivatable : ActivatableObject
{
    [SerializeField]
    private List<EnemySpawner> _arenaSpawners;
    
    [SerializeField]
    private List<ArenaDoor> _arenaDoors;



    private IEnumerator ArenaFightRoutine()
    {
        foreach (var door in _arenaDoors)
        {
            door.Close();
        }
        foreach (var spawner in _arenaSpawners)
        {
            Debug.Log("spawnerActivate");
            spawner.Activate();
        }

        while (!FightIsFinish())
        {
            yield return null;
        }
        
        foreach (var door in _arenaDoors)
        {
            door.Open();
        }
        
        
    }

    private bool FightIsFinish()
    {
        foreach (var spawner in _arenaSpawners)
        {
            if (!spawner.AllEnemiesSpawned)
                return false;
            if (spawner.SpawnedAliveEnemyCount() > 0)
                return false;
        }
        return true;
    }
    public override void Activate()
    {
        StartCoroutine(ArenaFightRoutine());
    }
    
}
