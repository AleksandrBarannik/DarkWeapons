using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCharacterController : CharacterConrtoller
{
    [SerializeField]
    private PatrolPath _patrolPath;
    
    public PatrolPath PatrolPath
    {
        get => _patrolPath;
        set => _patrolPath = value;
    }

    private float _aggroRange = 5;

    [SerializeField]
    private GameObject _player;

    public GameObject Player
    {
        get => _player;
        set => _player = value;
    }

    private int _indexWaypoint;
    public Vector3 destenation;

    private void Start()
    {
        controllerTarget.Stats.onCharacterDied += DestroySelf;
    }

    private bool IsInPoint(Vector3 targetPoint)
    {
        bool isInPoint = Vector3.Distance(transform.position, targetPoint) <= 1f;
        return isInPoint;
    }
    
    
    private void Patrol(BasicCharacter targetPatrol)
    {
        destenation = _patrolPath.WaypointsPatrol[_indexWaypoint].position;
        targetPatrol.MoveTo(destenation);
        
        if (IsInPoint(destenation))
        {
            _indexWaypoint = Random.Range(0, _patrolPath.WaypointsPatrol.Count);
        }
    }
    
    private void PursuitAndAttack(BasicCharacter targetPresledovaniya)
    {
        var dist = Vector3.Distance(transform.position, _player.transform.position);
        var attackRange = targetPresledovaniya.GetComponent<Stats>().RangeAttack;
        if (_player != null && dist < _aggroRange )
        {
            if (dist < attackRange)
            {
                targetPresledovaniya.Stop();
                destenation = transform.position;
                targetPresledovaniya.Attack(_player);
                return;
            }
            destenation = _player.transform.position;
            targetPresledovaniya.MoveTo(destenation);
        }
    }

    
    
    protected override void ProcessInput(BasicCharacter target)
    {
       Patrol(target);
       PursuitAndAttack(target);
       
    }


    private void DestroySelf()
    {
        Destroy(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_aggroRange);
        
    }
}
