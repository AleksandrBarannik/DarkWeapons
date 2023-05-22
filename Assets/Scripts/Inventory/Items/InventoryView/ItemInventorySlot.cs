using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventorySlot : MonoBehaviour
{
    [SerializeField]
    private ItemInventoryView _itemView;
    
    public ItemInventoryView ItemView=> _itemView;

    public void SetItem(Item item)
    {
        _itemView.SetItem(item);
        _itemView.gameObject.SetActive(item != null);

    }
    
}
