using UnityEngine;
using UnityEngine.AI;


//Синхронизирует скорость анимации со скоростью навмешАгента
public class HeroController : MonoBehaviour
{
    Animator animator; // reference to the animator component
     NavMeshAgent agent; // reference to the NavMeshAgent

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        animator.SetFloat("Speed",agent.velocity.magnitude);

    }

    public void SetDestation(Vector3 destination)//запускает мешагент  и  останавливает сопрограмму  атаки при передвижении
    {
        StopAllCoroutines();
        agent.isStopped = false;
        agent.destination = destination;
    }

    
}
