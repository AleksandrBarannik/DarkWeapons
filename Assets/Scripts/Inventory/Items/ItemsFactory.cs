using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ItemsFactory : MonoBehaviour
{
    [Tooltip("Base prefab for Item")][SerializeField] 
    private ConsumableItemSceneView _consumableItemSceneView;
    
    [Tooltip("Base prefab for Item")][SerializeField] 
    private InstantItemSceneView _instantItemSceneView;

    [Tooltip("Base prefab for Item")][SerializeField] 
    private EquippableItemSceneView _equippableItemSceneView;


    [Tooltip("DataBase all Items")][SerializeField]
    private ItemsDataBase _itemsDataBase;

    private EquippableItem _equippableItem;
    private ConsumableItem _consumableItem;
    private InstantItem _instantItem;

    private Item _items;
    
    public ItemsFactory(ItemsDataBase dataBase)
    {
        _itemsDataBase = dataBase;
    }

    private void Start()
    {
        CreateSceneItem(3);
    }


    private Item FindItem(int id, out ItemSceneView itemPrefab)
    {
        _equippableItem = _itemsDataBase.EquippableItems.Find((item) => item.ID == id);
        if (_equippableItem != null)
        {
            itemPrefab = _equippableItemSceneView;
            return _equippableItem;
        }
        
        if (_equippableItem == null)
        {
            _consumableItem = _itemsDataBase.ConsumableItems.Find((item) => item.ID == id);
            
            if (_consumableItem != null)
            {
                itemPrefab = _consumableItemSceneView;
                return _consumableItem;
            }
            
            if (_consumableItem == null)
            {
                itemPrefab = _instantItemSceneView;
                _instantItem = _itemsDataBase.InstantItems.Find((item) => item.ID == id);
                
                return _instantItem;
            }
        }

        itemPrefab = null;
        return null;
    }

    public void CreateSceneItem(int id)
    {
        var targetItem = FindItem(id, out var _itemSceneView);
        
        _itemSceneView = _consumableItemSceneView;
        _itemSceneView.meshRenderer.material = targetItem.Material;
        _itemSceneView.meshFilter.name = targetItem.Name;
        _itemSceneView.meshFilter.mesh = targetItem.Mesh;
        _itemSceneView.scaleItem.localScale = targetItem.ScaleElement;
        _itemSceneView.Collider.size = targetItem.ColliderSize;
        _itemSceneView.Collider.center = Vector3.zero;
        Instantiate(_itemSceneView, transform.position, Quaternion.identity);
    }
}
