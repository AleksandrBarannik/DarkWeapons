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

    private float speed;
    
    private void Update()
    {
        speed = Mathf.Lerp(speed,agent.velocity.magnitude,Time.deltaTime * 10);
        animator.SetFloat("Speed",speed);

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
    
  // public void MoveEnemy(Vector3 destination)
   // {
     //   if (agent.transform.position == agent.pathEndPosition)
     //   {
      //      agent.destination = destination;
      //  }
        
    //}
    
    public void MoveEnemy(Vector3 destination)
    {
        if (agent.transform.position == agent.pathEndPosition)
        {
            agent.destination = destination;
        }
        
    }
    
    
    
    
}
