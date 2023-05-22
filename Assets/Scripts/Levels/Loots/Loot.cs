using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//Выдает награду за убитого моба
public class Loot : MonoBehaviour
{
    [SerializeField]
    private BasicCharacter _owner;
    
    private int jumpForce = 7;

    [SerializeField]
    private List<LootNote> _lootTable;

    private void Start()
    {
        _owner.Stats.onCharacterDied += DropLoot;
    }
    
    

    private void DropLoot()
    {
        foreach (var loot in _lootTable)
        {
            if (Random.Range(0, 100f) < loot.spawnChance)
            {
                var spawnedLoot = Instantiate(loot.LootObject,
                                            transform.position + Vector3.up , Quaternion.identity);
                
                spawnedLoot.Rigidbody.velocity = Vector3.up * jumpForce;
                spawnedLoot.Rigidbody.angularVelocity =
                    new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            }
        }
    }

    
}

[Serializable]
public class LootNote
{
    
    public ItemSceneView LootObject;
    
    [Range(0,100f)]
    public float spawnChance;
    
}
