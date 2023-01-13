using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Код выполняет замену курсора , передвижение Главного героя мышкой
public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer; // layermask используется для  выбора слоя в котором хранятся обьекты по которым можно ходить(изоляции рейкаста)

    public Texture2D pointer; // normal mouse pointer
    public Texture2D target; // target mouse pointer
    public Texture2D doorway; // doorway mouse pointer

    public Texture2D attack; //attack mouse pointer

    public Texture2D book;//armor mouse pointer

    
    public Texture2D trading; //trayding mouse pointer

    public Texture2D  flank; //Зелья


    public Events.EventVector3 OnClickEnvironment;

    void Update()
    {
        // Raycast into scene
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;

            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            
            else if (hit.collider.gameObject.tag == "Book")
            {
                Cursor.SetCursor(book,new Vector2(16,16),CursorMode.Auto);
            }
            else if (hit.collider.gameObject.tag == "Trading")
            {
                Cursor.SetCursor(trading,new Vector2(16,16),CursorMode.Auto);
            }

            else if (hit.collider.gameObject.tag == "Attack")
            {
                Cursor.SetCursor(attack,new Vector2(16,16),CursorMode.Auto);
            }

            else if (hit.collider.gameObject.tag == "Flank")
            {
                Cursor.SetCursor(flank,new Vector2(16,16),CursorMode.Auto);
            }


            
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }


            
            if (Input.GetMouseButtonDown(0))//Если нажата клавиша 
            {
                if (door)
                {
                    
                    //получаем доступ к трансформу луча рейкаста направленного к колайдера Двери
                    Transform doorway = hit.collider.gameObject.transform;
                    //Конечное положение будет из положения колайдера двери+на расстоянии 10 юнитов от начала прохода
                    OnClickEnvironment.Invoke(doorway.position + doorway.forward * 10);
                }
                else
                {
                    OnClickEnvironment.Invoke(hit.point);//передаем позицию агенту navmesh для обычного движения
                }
            }
        }
        
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);//Врубить стандартрый курсор
        }
    }
}



