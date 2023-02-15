using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
    private Animator animator; // reference to the animator component
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    private static readonly int Death = Animator.StringToHash("Death");


    public void UpdateVelocity(float velocity)
    {
        animator.SetFloat(Speed, velocity);
    }

    public void PlayAttackAnim()
    {
        animator.SetTrigger(Attack1);
    }
    
    public void PlayDeathAnim()
    {
        animator.SetTrigger(Death);
    }
    
}
