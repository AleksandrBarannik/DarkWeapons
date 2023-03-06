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
    
    private int jumpForce = 1000;

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
            if (Random.Range(0, 100f) < loot.probability)
            {
                Instantiate(loot.LootObject, transform.position, Quaternion.identity);
                
                loot.rigidbody.AddForce(Vector3.up * jumpForce);
            }
        }
    }

    
}

[Serializable]
public class LootNote
{
    //item 
    public GameObject LootObject;
    
    public Rigidbody rigidbody;
    
    [Range(0,100f)]
    public float probability;
    
}
