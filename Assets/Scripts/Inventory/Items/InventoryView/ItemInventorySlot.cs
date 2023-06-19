using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventorySlot : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    
    [SerializeField]
    private ItemInventoryView _itemView;
    
    public ItemInventoryView ItemView=> _itemView;
    
    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = 0.5f;

    private Item _item;

    private void Start()
    {
        _button.onClick.AddListener(ApplyItem);
    }


    public void SetItem(Item item)
    {
        _item = item;
        _itemView.SetItem(item);
        _itemView.gameObject.SetActive(item != null);
    }

    private void ApplyItem()
    {
        var timeSinceLastCLick = Time.time - lastClickTime;

        if (timeSinceLastCLick < DOUBLE_CLICK_TIME)
        {
            Debug.Log("DoubleClick");
            _item.OnInteract();
            if (_item != null)
            {
                if (_item.StackCount <= 0)
                {
                    SetItem(null);
                }
                else
                {
                    SetItem(_item);
                }
            }
        }

        lastClickTime = Time.time;
    }
}
