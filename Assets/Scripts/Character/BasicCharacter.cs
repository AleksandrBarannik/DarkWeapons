using UnityEngine;
using UnityEngine.AI;
using System.Collections;

//Move Player
public class BasicCharacter : MonoBehaviour
{
    [SerializeField]
    private Animator animator; // reference to the animator component
    [SerializeField]
    private NavMeshAgent agent; // reference to the NavMeshAgent

    [SerializeField] 
    private Stats _stats; //Ссылка на статы

    private float _speed;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private GameObject _attackTarget;
    
    private float _weaponRange;
    private float _coldDown;
    
    
    

    private void Update()
    {
        
       // _speed = Mathf.Lerp(_speed,agent.velocity.magnitude,Time.deltaTime * 10);
       _speed = _stats.Speed;
        animator.SetFloat(Speed, _speed);

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
        //animator.SetTrigger("Attack");
        DoHit();
        yield return new WaitForSeconds(_coldDown);
        
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
            }
            else
            {
                Debug.Log("Death");
            }
            
            
        }
    }




    public void Interact(InteractiveObject target)
    {
        target.ProcessInteraction(this);
    }
}
