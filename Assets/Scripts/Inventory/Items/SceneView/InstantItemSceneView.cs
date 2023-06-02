using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantItemSceneView :ItemSceneView
{
    protected override bool TryCollect()
    {
        return true;
    }
    
    
}
