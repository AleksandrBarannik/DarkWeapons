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
           
           Debug.Log("выполняется класс  KeyInput   и Верхний элемент стека  " + Game.Instance.ScreenController.Top());
           
           Game.Instance.ScreenController.Top().OnBackPressed();
          
           // Game.Instance.ScreenController.Push_T<PauseScreen>();
           Game.Instance.ScreenController.printSteck();
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Debug.Log("Нажата кнопка U");
            Game.Instance.ScreenController.Push_T<StatsScreen>();
            
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
           // Debug.Log("Нажата кнопка I");
            Game.Instance.ScreenController.Push_T<InventoryScreen>();
            
        }
    }
}
