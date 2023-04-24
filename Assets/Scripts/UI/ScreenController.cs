using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    private Stack<Screen> _screenStack = new Stack<Screen>();

    [SerializeField]
    private List<Screen> _allScreen;

    [SerializeField] 
    private Screen _startScreen;
    
    public void Start()
    {
        Push_T(_startScreen,false);
        
    }
    //основная реализация
    public void Push_T<TScreen>(TScreen screen, bool hidePrev = true) where TScreen : Screen
    {
       if (_screenStack.Contains(screen))
        {
            while (_screenStack.Peek()!= screen)
            {
                var popedScreen = _screenStack.Pop();
                popedScreen.OnPop();
                popedScreen.gameObject.SetActive(false);
            }
        }

       else if ( hidePrev && _screenStack.Count > 0 )
       {
           var popedScreen = _screenStack.Peek();
           if (popedScreen.GetType() != typeof(HUDScreen))
           {
               popedScreen.gameObject.SetActive(false);
           }
       }

       _screenStack.Push(screen);
        screen.gameObject.SetActive(true);
        

    }

    public void Push_T<TScreen>(bool hidePrev = true) where TScreen : Screen
    {
        var findedScreen = _allScreen.Find((element) => element.GetType() == typeof(TScreen));
        Debug.LogError($"push {findedScreen.gameObject.name}");
        Push_T(findedScreen,hidePrev);
       
    }

    //скрывает текущий экран  и пишит на вершину предыдущий
    public Screen Pop()
    { 
        var popedScreen = _screenStack.Pop();
        popedScreen.OnPop();
        
        popedScreen.gameObject.SetActive(false);
        
        var topScreen = _screenStack.Peek();
        topScreen.gameObject.SetActive(true);
        printSteck();
        return topScreen;

    }

    
    // возвращает верхний экран стека
    public Screen Top()
    {
        return _screenStack.Pop();
    }


    private void printSteck()
    {
        var str = $"[{_screenStack.Count}]";
        foreach (var screen in _screenStack)
        {
            str += screen.gameObject.name + "; ";
        }
        Debug.LogError(str);
    }

}
