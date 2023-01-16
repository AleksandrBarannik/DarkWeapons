using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// отвечает за перемещение через дверь к точке выхода и входа двери
public class MoveTrigger : InteractiveObject
{
    [SerializeField] 
    private Vector3 _pointToMove;
    
    [SerializeField]
    private Transform _objectToMove;
    public override void ProcessInteraction(BasicCharacter interactor)
    {
        if (_objectToMove != null)
        {
            interactor.MoveTo(_objectToMove.position);
        }
        else
        {
            interactor.MoveTo(_pointToMove);
        }
        
    }
}
