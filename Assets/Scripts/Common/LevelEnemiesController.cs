using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LevelEnemiesController  //Соддержит ссылки на всех врагов на уровне ,род обьект где создаются  враги в инспекторе)
{
    [SerializeField]
    private List<EnemyCharacterController > enemys; 
    public List<EnemyCharacterController > Enemies
    {
        get => enemys;
    }

    [SerializeField]
    private Transform _enemiesParent;

    public Transform EnemiesParent => _enemiesParent;

    //НОВОЕ ДОБАВИЛ:
    
    [SerializeField]
    public PatrolPath _patrolPath;
    
    [SerializeField]
    public GameObject _player;

}
        
