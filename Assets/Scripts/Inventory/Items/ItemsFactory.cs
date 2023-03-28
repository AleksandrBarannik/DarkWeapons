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
        CreateSceneItem(3);
    }

    private void CreateSceneItem(int id)
    {
        //найти элемент по индексу 
        _equippableItem = _itemsDataBase.EquippableItems.Find((item) => item.ID == id);
        _itemSceneView.ItemEquippable = _equippableItem;
        
       if (_equippableItem == null)
       {
           _consumableItem = _itemsDataBase.ConsumableItems.Find((item) => item.ID == id);
           _itemSceneView.itemConsumable = _consumableItem;
           
           if (_consumableItem == null)
           {
               _instantItem = _itemsDataBase.InstantItems.Find((item) => item.ID == id);
           }
           else Debug.Log("Элемент не найден");
       }
       
       Instantiate(_itemSceneView, transform.position, Quaternion.identity);
    }

    
    
}
