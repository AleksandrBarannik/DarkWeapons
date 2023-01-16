using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Move Player
public class BasicCharacter : MonoBehaviour
{
    [SerializeField]
    private Animator animator; // reference to the animator component
    [SerializeField]
    private NavMeshAgent agent; // reference to the NavMeshAgent

    
    private void Update()
    {
        animator.SetFloat("Speed",agent.velocity.magnitude);

    }

    public void MoveTo(Vector3 destination)
    {
        StopAllCoroutines();
        agent.isStopped = false;
        agent.destination = destination;
    }

    public void Interact(InteractiveObject target)
    {
        target.ProcessInteraction(this);
    }
    
}
