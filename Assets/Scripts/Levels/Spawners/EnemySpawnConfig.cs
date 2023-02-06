using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnConfig",menuName = "DarkWeapons/SpawnConfig")]

public class EnemySpawnConfig : ScriptableObject // содержит префабы создоваемых врагов на сцене и время через которое они появятся
{
    public List<EnemySpawnNode> spawnNodes;

}

[System.Serializable]
public struct EnemySpawnNode
{
    public BasicCharacter enemyToSpawn;
    public float delayBeforeSpawn;
   
    
    
}
