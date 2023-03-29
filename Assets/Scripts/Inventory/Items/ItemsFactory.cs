using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemsFactory : MonoBehaviour
{
    [SerializeField] 
    private ItemSceneView _itemSceneView;

    [SerializeField]
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
        CreateSceneItem(5);
    }


    private Item FindItem(int id)
    {
        _equippableItem = _itemsDataBase.EquippableItems.Find((item) => item.ID == id);
        if (_equippableItem != null)
        {
            _itemSceneView.ItemEquippable = _equippableItem;
            return _equippableItem;
        }
        if (_equippableItem == null)
        {
            _consumableItem = _itemsDataBase.ConsumableItems.Find((item) => item.ID == id);
            _itemSceneView.itemConsumable = _consumableItem;
            return _consumableItem;
        }
        if (_consumableItem == null)
        {
            _instantItem = _itemsDataBase.InstantItems.Find((item) => item.ID == id);
            _itemSceneView.itemInstant = _instantItem;
            return _instantItem;
        }
        
        return null;
    }

    private void CreateSceneItem(int id)
    {
        _itemSceneView.meshRenderer.material = FindItem(id).Material;
        _itemSceneView.meshFilter.name = FindItem(id).Name;
        _itemSceneView.meshFilter.mesh = FindItem(id).Mesh;
        _itemSceneView.scaleItem.localScale = FindItem(id).ScaleElement;
        
        Instantiate(_itemSceneView, transform.position, Quaternion.identity);
    }
}
