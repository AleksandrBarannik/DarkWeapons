using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    private Stack<Screen> _screenStack;

    [SerializeField]
    private List<Screen> _allScreen;

    [SerializeField] 
    private Screen _startScreen;

    public void Start()
    {
        Push(_startScreen);
    }
    
    
    //основная реализация
    public void Push<TScreen>(TScreen screen,bool hidePrev = true) where TScreen : Screen
    {
        
    }
    
    
    public void Push<TScreen>(bool hidePrev = true) where TScreen : Screen
    {
        
    }

    //скрывает текущий экран  и возвращает предыдущий
    public Screen Pop()
    {
        throw  new  NotImplementedException();
    }

    
    // отправляет экран на вершину стека
    public Screen OnTop()
    {
        throw  new  NotImplementedException();
    }
    

}
