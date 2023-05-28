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

    private ItemsFactory _itemsFactory;
    
    private int jumpForce = 7;

    [SerializeField] private Transform EnemyPosition;

    [SerializeField]
    private List<LootNote> _lootTable;

    private void Start()
    {
        _itemsFactory = Game.Instance.Player.itemsFactory;
        _owner.Stats.onCharacterDied += DropLoot;
    }
    
    

    private void DropLoot()
    {
        foreach (var loot in _lootTable)
        {
            if (Random.Range(0, 100f) < loot.spawnChance)
            {
                var spawnedLoot = _itemsFactory.CreateSceneItem(loot.LootId, EnemyPosition) ;
               // var spawnedLoot = Instantiate(loot.LootObject,
                                           // transform.position + Vector3.up , Quaternion.identity);
                
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
    public int LootId;
    
    public ItemSceneView LootObject ;
    
    [Range(0,100f)]
    public float spawnChance;
    
}
