using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    public  abstract void ProcessInteraction(BasicCharacter interactor);
}
