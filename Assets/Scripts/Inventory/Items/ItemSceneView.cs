using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSceneView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;

    public MeshRenderer meshRenderer;
    
    public MeshFilter meshFilter;

    public Transform scaleItem;

    
    public  EquippableItem ItemEquippable;
    
    public  ConsumableItem itemConsumable;
    
    public  InstantItem itemInstant;
    
}
