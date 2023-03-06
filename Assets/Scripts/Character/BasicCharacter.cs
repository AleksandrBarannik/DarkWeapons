using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

//Move Player
public class BasicCharacter : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody _rigidbody;

    [SerializeField]
    private Collider _collider;
    
  
    [SerializeField] 
    private CharacterView _characterView;
    
    [SerializeField]
    private NavMeshAgent agent; // reference to the NavMeshAgent

    [SerializeField] 
    private Stats _stats; //Ссылка на статы

    public Stats Stats => _stats;


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
        if (_stats.IsDead)
            return;
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
        if (_stats.IsDead)
            return;
        StopAllCoroutines();
        agent.isStopped = false;
        //Debug.LogError($"{gameObject.name}: set target {target.name}");
        _attackTarget = target;
        _weaponRange = _stats.RangeAttack;
        _coldDown = _stats.ColdDownAttack;
        StartCoroutine(PursueTarget());
    }

    private IEnumerator PursueTarget()
    {
        if (_stats.IsDead)
            yield break;
        
        while (Vector3.Distance(transform.position, _attackTarget.transform.position) > _weaponRange)
        {
            agent.destination = _attackTarget.transform.position;
            yield return null;
        }
        //Debug.LogError($"{gameObject.name}: agent.isStopped");
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
        //Debug.LogError($"{gameObject.name}: do hit Enter ");
        if (_attackTarget != null)
        {
            //Debug.LogError($"{gameObject.name}: attack target != NULL ");
            var attackDamage = _stats.AttackDamage;
            var _statsAttackTarget = _attackTarget.GetComponent<Stats>();
            
            if (_statsAttackTarget.currentHealthPoints >0)
            {
                //Debug.LogError($"{gameObject.name}: CurrentPoints > 0 ");
                _statsAttackTarget.ChangeHealth(attackDamage);
                nextAttackTime = Time.time + _coldDown;
            }
            
            
            
        }
    }


    public void Interact(InteractiveObject target)
    {
        if (_stats.IsDead)
            return;
        target.ProcessInteraction(this);
    }

    private void Died()
    {
        
        StopAllCoroutines();
        _characterView.PlayDeathAnim();
        Destroy(_rigidbody);
        Destroy(_collider);
        
    }

}