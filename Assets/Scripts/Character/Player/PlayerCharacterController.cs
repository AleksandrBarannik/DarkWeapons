using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Перемещение  персонажа для интерактивного обьекта дверь
public class PlayerCharacterController : CharacterConrtoller
{
    public LayerMask clickableLayer;

    public GameObject enemy;
    
    protected override void ProcessInput(BasicCharacter target)
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
            {
                var interactedTarget = hit.collider.gameObject.GetComponent<InteractiveObject>();
                if (interactedTarget != null)
                {
                    target.Interact(interactedTarget);
                }

                else
                {
                    target.MoveTo(hit.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            target.Attack(enemy);
        }


    }
}
