using System;
using TMPro;
using UnityEngine;

public class CameraSmoothFollowTarget : MonoBehaviour
{   

    public GameObject target;
    Vector3 offset;

    bool b;

    private void LateUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        else
        {
            if (!b)
            {
                offset = transform.position - target.transform.position;
                b = true;
            }

            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 10);
            return;
        }
    }
}

