using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Отвечает за запуск анимации ( врагов боссов главного персонажа)
public class CharacterView : MonoBehaviour
{
    [SerializeField]
    private Animator animator; // reference to the animator component
    
    [SerializeField]
    private SkinnedMeshRenderer _meshRenderer;
    public SkinnedMeshRenderer MeshRenderer => _meshRenderer;
    
    
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
    
    public void Blink()//Мерцание моба
    {
        StartCoroutine(BlinkCoroutine());
    }
    
    public void PlayDeathAnim()
    {
        animator.SetTrigger(Death);
    }

    private IEnumerator BlinkCoroutine()
    {
        Color clr = Color.white;
        MaterialPropertyBlock blockProperty = new MaterialPropertyBlock();
        MeshRenderer.GetPropertyBlock(blockProperty);

        for (int i = 0 ; i < 20; i++)
        {
            clr = new Color(1, 1 - i * 0.05f, 1 - i * 0.05f);
            blockProperty.SetColor("_Color",clr);
            MeshRenderer.SetPropertyBlock(blockProperty);
            yield return null;
        }
        
        for (int i = 20 ; i >= 0; i--)
        {
            clr = new Color(1, 1-i*0.05f , 1-i*0.05f );
            blockProperty.SetColor("_Color",clr);
            MeshRenderer.SetPropertyBlock(blockProperty);
            yield return null;
        }
        
        
    }
    
}
