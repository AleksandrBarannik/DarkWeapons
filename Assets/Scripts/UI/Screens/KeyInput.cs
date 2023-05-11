using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Отвечает за нажаты клавиши
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
                        
                            //Debug
           //Game.Instance.ScreenController.printSteck();
           
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (Game.Instance.ScreenController.Top() is StatsScreen)
                Game.Instance.ScreenController.Pop();
            else
                Game.Instance.ScreenController.Push_T<StatsScreen>();
            
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Game.Instance.ScreenController.Top() is InventoryScreen)
                Game.Instance.ScreenController.Pop();
            else
                Game.Instance.ScreenController.Push_T<InventoryScreen>();
        }
    }
}
