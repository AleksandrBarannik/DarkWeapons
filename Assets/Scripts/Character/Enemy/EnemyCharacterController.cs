using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : CharacterConrtoller
{
    [SerializeField]
    private List <Transform> _waypointsPatrol;
    
    [SerializeField]
    private float _aggroRange = 5;

    [SerializeField]
    private Transform _player;

    private int indexWaypoint;

    
    public Vector3 destenation;


    private bool IsInPoint(Vector3 targetPoint)
    {
        bool isInPoint = Vector3.Distance(transform.position, targetPoint) <= 1f;
        return isInPoint;
    }
    
    
    private void Patrol(BasicCharacter targetPatrol)
    {
        destenation = _waypointsPatrol[indexWaypoint].position;
        targetPatrol.MoveTo(destenation);
        
        if (IsInPoint(destenation))
        {
            indexWaypoint = Random.Range(0, _waypointsPatrol.Count);
        }
    }
    
    private void Presledovaniye(BasicCharacter targetPresledovaniya)
    {
        if (_player != null && Vector3.Distance(transform.position,_player.position) < _aggroRange)
        {
            destenation = _player.position;
            targetPresledovaniya.MoveTo(destenation);
        }
    } 

    
    protected override void ProcessInput(BasicCharacter target)
    {
       Patrol(target);
       Presledovaniye(target);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_aggroRange);
        
    }
}
