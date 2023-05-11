using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Перемещение  персонажа  по рейкасту по нажатию мыши  и  атака по нажатию кнопки мыши
public class PlayerCharacterController : CharacterConrtoller
{
    public LayerMask clickableLayer;

    public  List<EnemyCharacterController> enemys;

    private int _staminaAmount = 2;
    
    
    

   protected override void ProcessInput(BasicCharacter target)
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                                                             out hit, 50, clickableLayer.value))
            {
                var interactedTarget = hit.collider.gameObject.GetComponent<InteractiveObject>();
                if (interactedTarget != null)
                {
                    target.Interact(interactedTarget);
                }
                

                else
                {
                    var attackTarget = hit.collider.gameObject.GetComponent<EnemyCharacterController>();
                    if (attackTarget != null)
                    {
                        target.Attack(attackTarget.gameObject);
                    }
                    else
                    {
                        target.MoveTo(hit.point);
                    }
                    
                }
            }
        }

        


    }
}
