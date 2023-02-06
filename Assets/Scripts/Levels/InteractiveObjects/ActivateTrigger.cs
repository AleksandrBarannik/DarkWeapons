using System.Collections.Generic;
using UnityEngine;

//Активирует  различные обьекты на сцене  по тригерам
public class ActivateTrigger: InteractiveObject
{
    [SerializeField] private List<ActivatableObject> _activatableObjects;
    public override void ProcessInteraction(BasicCharacter interactor)
    {
        foreach (var activatableObject in _activatableObjects)
        {
            activatableObject.Activate();
        }
    }
}
