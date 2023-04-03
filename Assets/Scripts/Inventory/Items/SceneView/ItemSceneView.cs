using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class ItemSceneView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;
    
    public MeshFilter meshFilter;

    public MeshRenderer meshRenderer; //Дописать свойствами
    
    public Transform scaleItem;

    [SerializeField]
    private BoxCollider _boxCollider;
    public BoxCollider Collider => _boxCollider;
    
    public  Item Item;
    
}
