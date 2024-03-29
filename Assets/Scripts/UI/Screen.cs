using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Screen : MonoBehaviour
{
   public virtual void OnPush() {}
   public virtual void OnPop() {}

   public virtual void OnBackPressed()
   {
      Game.Instance.ScreenController.Pop();
   }
}
