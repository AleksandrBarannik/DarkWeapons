using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    [SerializeField]
    private List <Transform> _waypointsPatrol;

    public List<Transform> WaypointsPatrol
    {
        get => _waypointsPatrol;
        set => _waypointsPatrol = value;
    }
}
