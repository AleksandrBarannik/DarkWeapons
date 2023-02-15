using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventBus
{
   public event Action <EnemyCharacterController> onEnemySpawn;

   public void OnEnemySpawn(EnemyCharacterController enemyCharacterController)
   {
      onEnemySpawn?.Invoke(enemyCharacterController);
   }
}
