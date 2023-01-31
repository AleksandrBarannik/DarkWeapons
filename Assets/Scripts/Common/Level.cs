using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] 
    private GameObject _currentLevel;
    [SerializeField]
    private PlayerCharacterController mainCharacter;
    [SerializeField]
    private EnemyCharacterController [] enemys; //Заменить на list

    public EnemyCharacterController[] Enemies
    {
        get => enemys;
    }

    //private PatrolPath[] waypointsPatrol;
}
