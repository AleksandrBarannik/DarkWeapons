using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginArenaFightTrigger : Trigger
{
    [SerializeField] private List<ActivatableObject> _activatableObjects;
   
    protected  override  void ActivateTrigger()
    {
        foreach (var activatableObject in _activatableObjects)
        {
            activatableObject.Activate();
        }
    }
}
