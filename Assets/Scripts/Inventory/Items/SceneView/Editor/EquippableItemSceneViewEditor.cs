using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EquippableItemSceneView))]
public class EquippableItemSceneViewEditor : Editor
{
    private int selectedIndex;
    private List<EquippableItem> itemList;
    private string[] displayedOptions;
    private ItemsDataBase _itemsDataBase;
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (_itemsDataBase == null)
        {
            _itemsDataBase =
                AssetDatabase.LoadAssetAtPath<ItemsDataBase>("Assets/Configs/ItemsConfig/ItemsDataBase.asset"); //загрузить ассет не запуская игру
            
            itemList = _itemsDataBase.EquippableItems;
            
            var options = new List<string>();

            foreach (var item in itemList)
            {
                options.Add($"{item.ID} {item.Name}");
            }

            selectedIndex = -1;
            displayedOptions = options.ToArray();
        }
        else
        {
            var prevSelectedIndex = selectedIndex;
            selectedIndex = EditorGUILayout.Popup("Item", selectedIndex, displayedOptions);

            if (prevSelectedIndex != selectedIndex && selectedIndex >= 0)
            {
                var itemSceneView = target as ItemSceneView;
                ItemsFactory.FillItemSceneView(itemSceneView,itemList[selectedIndex].Copy());
                EditorUtility.SetDirty(target);//помечает обьект измененым (чтобы юнити сохранил)
            }
        }

    }
}
