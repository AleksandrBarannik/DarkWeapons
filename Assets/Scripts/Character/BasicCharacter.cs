using UnityEngine;
using UnityEngine.AI;

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
    
    public void Interact(InteractiveObject target)
    {
        target.ProcessInteraction(this);
    }
}
