using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantItemSceneView :ItemSceneView
{
    [SerializeField] public InstantItem instantItem;
    public override Item Item
    {
        get { return instantItem; }
        set { instantItem = (InstantItem) value; }
    }
    protected override bool TryCollect()
    {
        return true;
    }
    
    
}
