using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Screen : MonoBehaviour
{
   //[SerializeField]
  // private Screen _type;

 //  public Screen Type => _type;
   
   public virtual void OnPush() {}
   public virtual void OnPop() {}
}
