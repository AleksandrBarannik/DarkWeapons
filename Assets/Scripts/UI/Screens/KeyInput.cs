using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    [SerializeField] 
    private ScreenController _screenController;
    
    [SerializeField]
    private PauseScreen _pauseScreen;

    [SerializeField] 
    private StatsScreen _statsScreen;
    
    [SerializeField] 
    private InventoryScreen _inventoryScreen;
    
    void Update()
    {
        InputControlKey();
    }

    private void InputControlKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // _pauseScreen.gameObject.SetActive(true);
           Debug.Log("Нажата кнопка ESCape");
           _screenController.Push_T(_pauseScreen);
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Нажата кнопка I");
            _screenController.Push_T(_statsScreen);
            //_statsScreen.gameObject.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Нажата кнопка I");
            _screenController.Push_T(_inventoryScreen);
            //_inventoryScreen.gameObject.SetActive(true);
        }
    }
}
