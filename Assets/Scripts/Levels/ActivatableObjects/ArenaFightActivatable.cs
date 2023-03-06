using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFightActivatable : ActivatableObject
{
    private List<EnemySpawner> _arenaSpawners;
    private List<ArenaDoor> _arenaDoors;



    private IEnumerator ArenaFightRoutine()
    {
        foreach (var door in _arenaDoors)
        {
            door.Close();
        }
        foreach (var spawner in _arenaSpawners)
        {
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
