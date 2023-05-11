using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Отвечает за анимацию открытия и закрытия дверей на Арене
public class ArenaDoor : MonoBehaviour
{
    [SerializeField]
    private Animator _doorAnimator;

    [SerializeField] private bool IsOpenDoorByLevelStart = true;

    private static readonly int Open1 = Animator.StringToHash("Open");

    private void Start()
    {
        if (IsOpenDoorByLevelStart)
            Open();
        else
        {
            Close();
        }
    }

    public void Open()
    {
        _doorAnimator.SetBool(Open1,true);
    }

    public void Close()
    {
        _doorAnimator.SetBool(Open1,false);
    }
    
}
