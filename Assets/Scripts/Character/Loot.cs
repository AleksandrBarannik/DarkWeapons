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
    
    private int jumpForce = 100;

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
                
                loot.LootObject.Rigidbody.AddForce(Vector3.up * jumpForce);
            }
        }
    }

    
}

[Serializable]
public class LootNote
{
    //item 
    public Item LootObject;
    
    [Range(0,100f)]
    public float probability;
    
}
