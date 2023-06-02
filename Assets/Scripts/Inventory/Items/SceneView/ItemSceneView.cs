using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract  class ItemSceneView : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;
    
    [SerializeField]
    private BoxCollider _boxCollider;
    public BoxCollider Collider => _boxCollider;
    
    [SerializeField] 
    private MeshFilter _meshFilter;
    public MeshFilter FilterMesh => _meshFilter;
    
    [SerializeField]
    private MeshRenderer _meshRenderer;
    public MeshRenderer RendererMesh => _meshRenderer;
    
    [SerializeField]
    private Transform scaleItem;
    public Transform ScaleItem => scaleItem;

    public  Item Item;

   
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Game.Instance.Player.Character.gameObject)
        {
            if (TryCollect())
            {
                 OnCollect();
                 Destroy(this.gameObject);
            }
            
        }
    }

    //подьем предмета

    protected abstract bool TryCollect();
    
    protected virtual void OnCollect()
    {
        Item.OnCollect();
    }
}
