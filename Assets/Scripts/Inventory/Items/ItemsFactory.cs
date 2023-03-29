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
    
    public ItemsFactory(ItemsDataBase dataBase)
    {
        _itemsDataBase = dataBase;
    }

    private void Start()
    {
        CreateSceneItem(1);
    }

    private void CreateSceneItem(int id)
    {
        //найти элемент по индексу 
        _equippableItem = _itemsDataBase.EquippableItems.Find((item) => item.ID == id);
        if (_equippableItem != null)
        {
            _itemSceneView.ItemEquippable = _equippableItem;
            _itemSceneView.meshRenderer.material = _equippableItem.Material;
            _itemSceneView.meshFilter.name = _equippableItem.Name;
            _itemSceneView.meshFilter.mesh = _equippableItem.Mesh;
            _itemSceneView.scaleItem.localScale = _equippableItem.ScaleElement;

        }
        else if (_equippableItem == null)
        {
            _consumableItem = _itemsDataBase.ConsumableItems.Find((item) => item.ID == id);
            if (_consumableItem != null)
            {
                _itemSceneView.itemConsumable = _consumableItem;
                _itemSceneView.meshRenderer.material = _consumableItem.Material;
                _itemSceneView.meshFilter.name = _consumableItem.Name;
                _itemSceneView.meshFilter.mesh = _consumableItem.Mesh;
                _itemSceneView.scaleItem.localScale = _consumableItem.ScaleElement;
            }

            else if (_consumableItem == null)
            {
                _instantItem = _itemsDataBase.InstantItems.Find((item) => item.ID == id);
                if (_instantItem != null)
                {
                    _itemSceneView.itemInstant = _instantItem;
                    _itemSceneView.meshRenderer.material = _instantItem.Material;
                    _itemSceneView.meshFilter.name = _instantItem.Name;
                    _itemSceneView.meshFilter.mesh = _instantItem.Mesh;
                    _itemSceneView.scaleItem.localScale = _instantItem.ScaleElement;
                   
                   
                }
                else Debug.Log("Элемент не найден");
            }
           
        }
       
        Instantiate(_itemSceneView, transform.position, Quaternion.identity);
    }
    

    
    
}
