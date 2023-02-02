using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : CharacterConrtoller
{
    [SerializeField]
    private List <Transform> _waypointsPatrol;
    
    [SerializeField]
    private float _aggroRange = 5;

    [SerializeField]
    private GameObject _player;
    
    private int _indexWaypoint;
    public Vector3 destenation;
    
    


    private bool IsInPoint(Vector3 targetPoint)
    {
        bool isInPoint = Vector3.Distance(transform.position, targetPoint) <= 1f;
        return isInPoint;
    }
    
    
    private void Patrol(BasicCharacter targetPatrol)
    {
        destenation = _waypointsPatrol[_indexWaypoint].position;
        targetPatrol.MoveTo(destenation);
        
        if (IsInPoint(destenation))
        {
            _indexWaypoint = Random.Range(0, _waypointsPatrol.Count);
        }
    }
    
    private void Pursuit(BasicCharacter targetPresledovaniya)
    {
        var dist = Vector3.Distance(transform.position, _player.transform.position);
        if (_player != null && dist < _aggroRange)
        {
            if (dist < 2)
            {
                targetPresledovaniya.Stop();
                destenation = transform.position;
                return;
            }
            destenation = _player.transform.position;
            targetPresledovaniya.MoveTo(destenation);
        }
    }

    
    
    protected override void ProcessInput(BasicCharacter target)
    {
       Patrol(target);
       Pursuit(target);
       //target.Attack(_player);
       
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_aggroRange);
        
    }
}
