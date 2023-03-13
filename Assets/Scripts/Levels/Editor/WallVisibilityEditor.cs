using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WallVisibility))]
public class WallVisibilityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("testFor2sec"))
        {
            var wallVisibility = target as WallVisibility;
            wallVisibility.HideFor(2f);
        }
    }
}
