using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [SerializeField]
    private ActivateType activateType;

    private bool _canUse = true;
    protected abstract void ActivateTrigger();
    private void OnTriggerEnter(Collider other)
    {
        if (!_canUse)
            return;
        if (other.gameObject == Game.Instance.Player.Character.gameObject)
        {
            ActivateTrigger();
            if (activateType == ActivateType.Single)
                _canUse = false;

        }
        

    }
}

public enum ActivateType
{
    Single = 1,
    Multiple = 2
}
