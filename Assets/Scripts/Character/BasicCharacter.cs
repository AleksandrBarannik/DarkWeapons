using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

//Move Player
public class BasicCharacter : MonoBehaviour
{
    [SerializeField] 
    private CharacterView _characterView;
    
    [SerializeField]
    private NavMeshAgent agent; // reference to the NavMeshAgent

    [SerializeField] 
    private Stats _stats; //Ссылка на статы

  
    private GameObject _attackTarget;
    
    private float _weaponRange;
    private float _coldDown;
    private float nextAttackTime;


    private void Awake()
    {
        nextAttackTime = _stats.ColdDownAttack;
        agent.speed = _stats.Speed;
    }
    
    private void Start()
    {
        _stats.onCharacterDied += Died;
    }


    private void Update()
    {
        _characterView.UpdateVelocity(agent.velocity.magnitude);
       
    }
    
    public void MoveTo(Vector3 destination)
    {
        StopAllCoroutines();
        agent.isStopped = false;
        agent.destination = destination;

    }

    public void Stop()
    {
        StopAllCoroutines();
        agent.isStopped = true;
        agent.destination = transform.position;
    }

    public void Attack(GameObject target)
    {
        StopAllCoroutines();
        agent.isStopped = false;
        
        _attackTarget = target;
        _weaponRange = _stats.RangeAttack;
        _coldDown = _stats.ColdDownAttack;
        StartCoroutine(PursueTarget());
    }

    private IEnumerator PursueTarget()
    {
        while (Vector3.Distance(transform.position, _attackTarget.transform.position) > _weaponRange)
        {
            agent.destination = _attackTarget.transform.position;
            yield return null;
        }
        agent.isStopped = true;
        transform.LookAt(_attackTarget.transform);
        if (!(Time.time < nextAttackTime))
        {
            _characterView.PlayAttackAnim();
            DoHit();
        }
    }

    public void DoHit()
    {
        if (_attackTarget != null)
        {
            var attackDamage = _stats.AttackDamage;
            var _statsAttackTarget = _attackTarget.GetComponent<Stats>();
            
            if (_statsAttackTarget.currentHealthPoints >0)
            {
                _statsAttackTarget.ChangeHealth(attackDamage);
                nextAttackTime = Time.time + _coldDown;
            }
            
            
            
        }
    }


    public void Interact(InteractiveObject target)
    {
        target.ProcessInteraction(this);
    }

    private void Died()
    {
        StopAllCoroutines();
        _characterView.PlayDeathAnim();
        
    }

}