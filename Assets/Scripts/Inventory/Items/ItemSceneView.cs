using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSceneView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;

    public  EquippableItem ItemEquippable;
    
    public  ConsumableItem itemConsumable;
    
    public  InstantItem itemInstant;
    
}
