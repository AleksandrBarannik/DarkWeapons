using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventorySlot : MonoBehaviour
{
    [SerializeField]
    private ItemInventoryView _itemView;
    
    public ItemInventoryView ItemView=> _itemView;
    
    [SerializeField]
    private int maxCountObjectInSlot = 20;
    public int MaxCountObject => maxCountObjectInSlot;
    
    private int _currentCountObjectInSlot;
    public int CurrentCountObjectInSlot => _currentCountObjectInSlot;
    
    
    

    public void SetItem(Item item)
    {
        _itemView.SetItem(item);
        _itemView.gameObject.SetActive(item != null);
    }

    public void UpdateCountObjectInSlots(ConsumableItem item)
    {
        
        //Осталось понять где изменить количество обьектов в слоте и где вызывать  эту функциию
        _itemView.SetItem(item, _currentCountObjectInSlot);
    }
    
    
}
