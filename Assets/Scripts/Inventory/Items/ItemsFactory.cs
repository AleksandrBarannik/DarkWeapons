using UnityEngine;

    //СОздает предмет на сцене  по айдишнику  и из базы данных предмета  передает его значения ему 
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
        CreateSceneItem(5);
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
        var targetItem = FindItem(id, out var itemSceneView);
        var spawnItem = Instantiate(itemSceneView, transform.position, Quaternion.identity);
        
        //_itemSceneView = _consumableItemSceneView;
        spawnItem.RendererMesh.material = targetItem.Material;
        spawnItem.FilterMesh.name = targetItem.Name;
        spawnItem.FilterMesh.mesh = targetItem.Mesh;
        spawnItem.ScaleItem.localScale = targetItem.ScaleElement;
        spawnItem.Collider.size = targetItem.ColliderSize;
        spawnItem.Collider.center = targetItem.ColliderCenter;
        spawnItem.Item = targetItem;
        
       
    }
}
