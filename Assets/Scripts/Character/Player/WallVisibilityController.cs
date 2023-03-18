using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisibilityController : MonoBehaviour
{
    void Update()
    {
        var direction = Game.Instance.Level.MainCharacter.transform.position - Camera.main.transform.position;
        if (Physics.Raycast(Camera.main.transform.position,direction,
            out var hit,
            50))
        {
            var wallVisibillity = hit.collider.gameObject.GetComponent<WallVisibility>();
            if (wallVisibillity != null)
                wallVisibillity.HideFor(2f);
        }
    }
}