using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    void Update()
    {
        InputControlKey();
    }

    private void InputControlKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Debug.Log("Нажата кнопка ESCape");
           Game.Instance.ScreenController.Top().OnBackPressed();
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Нажата кнопка U");
            Game.Instance.ScreenController.Push_T<StatsScreen>();
            
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Нажата кнопка I");
            Game.Instance.ScreenController.Push_T<InventoryScreen>();
            
        }
    }
}
