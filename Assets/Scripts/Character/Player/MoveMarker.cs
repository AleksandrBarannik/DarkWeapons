using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarker : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private readonly int Play = Animator.StringToHash("Play");

    private void Start()
    {
        transform.parent = null;
    }
    public void MarkPoint(Vector3 point)
    {
        transform.position = point + Vector3.up * 0.01f;
        _animator.SetTrigger(Play);
    }
    
}
