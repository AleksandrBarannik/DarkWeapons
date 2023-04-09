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
        CreateSceneItem(1);
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
        _itemSceneView.RendererMesh.material = targetItem.Material;
        _itemSceneView.FilterMesh.name = targetItem.Name;
        _itemSceneView.FilterMesh.mesh = targetItem.Mesh;
        _itemSceneView.ScaleItem.localScale = targetItem.ScaleElement;
        _itemSceneView.Collider.size = targetItem.ColliderSize;
        _itemSceneView.Collider.center = targetItem.ColliderCenter;
        Instantiate(_itemSceneView, transform.position, Quaternion.identity);
    }
}
