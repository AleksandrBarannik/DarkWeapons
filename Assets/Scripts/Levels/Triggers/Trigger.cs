using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [SerializeField]
    private ActivateType activateType;
    protected abstract void ActivateTrigger();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Game.Instance.Player.Character.gameObject)
        {
            ActivateTrigger();
            if (activateType == ActivateType.Single)
                this.gameObject.SetActive(false);

        }

    }
}

public enum ActivateType
{
    Single = 1,
    Multiple = 2
}
