using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisibility : MonoBehaviour
{
   [SerializeField]
   private List<MeshRenderer>  _wallMesh;

   private float _showTime;

   private void Update()
   {
      if (Time.time > _showTime)
         Show();
   }

   public void HideFor(float seconds)
   {
      Hide();
      _showTime = Time.time + seconds;
   }

   private void Hide()
   {
      foreach (var wallMesh in _wallMesh)
      {
         wallMesh.material.color = new Color(1,1,1,0.5f);
      }
      
   }
   
   private void Show()
   {
      foreach (var wallMesh in _wallMesh)
      {
         wallMesh.material.color = new Color(1,1,1,1);
      }
      
   }
   
}
