using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] 
    private GameObject _currentLevel;
    [SerializeField]
    private PlayerCharacterController mainCharacter;
    [SerializeField]
    private EnemyCharacterController [] enemys;

    //private PatrolPath[] waypointsPatrol;
}
