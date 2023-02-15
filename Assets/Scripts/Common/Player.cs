using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private BasicCharacter _Character;
    public BasicCharacter Character => _Character;
    
    [SerializeField]
    private PlayerCharacterController _player;
}
