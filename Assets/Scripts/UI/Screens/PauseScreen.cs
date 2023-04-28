using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : Screen
{
    public override void OnBackPressed()
    {
        Debug.Log("Выполнился OnBackPressed в  Классе PauseScreen");
        
        Game.Instance.UnPause();
    }
    
}
