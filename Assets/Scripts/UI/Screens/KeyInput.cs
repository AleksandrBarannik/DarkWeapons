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
          
           Game.Instance.ScreenController.Top().OnBackPressed();
          
           // Game.Instance.ScreenController.Push_T<PauseScreen>();
           Game.Instance.ScreenController.printSteck();
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Debug.Log("Нажата кнопка U");
            if (Game.Instance.ScreenController.Top() is StatsScreen)
                Game.Instance.ScreenController.Pop();
            else
                Game.Instance.ScreenController.Push_T<StatsScreen>();
            
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
           // Debug.Log("Нажата кнопка I");
            Game.Instance.ScreenController.Push_T<InventoryScreen>();
            
        }
    }
}
