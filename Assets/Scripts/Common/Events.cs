using UnityEngine.Events;
using UnityEngine;
public class Events 
{
    //Для создания UnityEvent( c аргументыми какое состояние было и какое стало )
//[System.Serializable] public class EventsGameState:UnityEvent<GameManager.GameState,GameManager.GameState>{}//Ивент игрового статуса
//[System.Serializable] public class EventsFadeComplete:UnityEvent<bool>{}//Ивент успешного затухания меню (гамманаджер)



//Ивенты для класса MouseManager
[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>//Для отправки данных Vector3 через Event
{}

[System.Serializable]
public class EventGameObject: UnityEvent<GameObject>//Ивент принимающий игровые обьекты
{}




    
}
