using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterConrtoller : MonoBehaviour
{
    [SerializeField]
    protected BasicCharacter controllerTarget;

    public BasicCharacter ControllerTarget => controllerTarget;
    private void Update()
    {
        ProcessInput(controllerTarget);
    }

    protected abstract void ProcessInput(BasicCharacter target);

}
