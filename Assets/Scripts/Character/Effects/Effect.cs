using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect:ScriptableObject
{
    public virtual void OnApply(BasicCharacter basicCharacter) {}
    
    public abstract Effect Copy();
}
