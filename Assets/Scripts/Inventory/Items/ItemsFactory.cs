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
    
    public ItemsFactory(ItemsDataBase dataBase)
    {
        _itemsDataBase = dataBase;
    }

    private void CreateSceneItem(int id)
    {
        
    }
    
    
}
