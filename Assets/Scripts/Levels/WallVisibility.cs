using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisibility : MonoBehaviour
{
   [SerializeField]
   private List<MeshRenderer>  _wallMesh;

   private float _showTime;
   
   private  float targetAlpha = 1f;

   private float currentAlpha = 1f;
   
   private void Update()
   {
      if (Time.time > _showTime)
         Show();
      if (currentAlpha == targetAlpha) return;
      
      UpdateAlpha();
   }

   private void UpdateAlpha()
   {
      if (targetAlpha > currentAlpha)
         currentAlpha = Mathf.Clamp(currentAlpha + Time.deltaTime , 0,targetAlpha);
      
      else if (targetAlpha < currentAlpha)
         currentAlpha = Mathf.Clamp(currentAlpha - Time.deltaTime,targetAlpha, 1);
      
      foreach (var wallMesh in _wallMesh)
      {         
         wallMesh.material.color = new Color(1,1,1,currentAlpha);
      }
   }

   public void HideFor(float seconds)
   {
      targetAlpha = 0.5f;
      _showTime = Time.time + seconds;
   }
   
   private void Show()
   {
      targetAlpha = 1f;
   }   

   }
