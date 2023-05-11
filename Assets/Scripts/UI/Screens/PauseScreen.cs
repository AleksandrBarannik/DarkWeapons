using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ОТвечает за UI панели паузы
public class PauseScreen : Screen
{
    public override void OnBackPressed()
    {
       Game.Instance.UnPause();
    }
    
}
