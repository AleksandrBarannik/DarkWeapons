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
    
    private Screen currentScreen;
    private Screen previewScreen;

    public void Start()
    {
        Push_T(_startScreen,false);
        
    }
    //основная реализация
    public void Push_T<TScreen>(TScreen screen, bool hidePrev = true) where TScreen : Screen
    {
        var findedScreen = _allScreen.Find((element) => element == screen);
        
        _screenStack.Push(findedScreen);
        if (hidePrev)
        {
            OnPop().gameObject.SetActive(false);
        }
        currentScreen = Top();

    }
    
    
    public void Push_T<TScreen>(bool hidePrev = true) where TScreen : Screen
    {
        
    }

    //скрывает текущий экран  и пишит на вершину предыдущий
    public Screen OnPop()
    { 
        currentScreen.gameObject.SetActive(true);
        if (_screenStack.Count != 0)
        {
            previewScreen = Top();
            previewScreen.gameObject.SetActive(true);
            _screenStack.Push(previewScreen);
            
        }
        currentScreen = previewScreen;
        return previewScreen;
    }

    
    // возвращает верхний экран стека
    public Screen Top()
    {
        return _screenStack.Pop();
    }
    

}
