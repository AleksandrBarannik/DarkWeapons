using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : CharacterConrtoller
{
    [SerializeField]
    private List <Transform> _waypointsPatrol;

    private int indexWaypoint;

    
    protected override void ProcessInput(BasicCharacter target)
    {
        var destenation = _waypointsPatrol[indexWaypoint].position;
        target.MoveEnemy(destenation);
        indexWaypoint = Random.Range(0, _waypointsPatrol.Count);
        
    }
}
