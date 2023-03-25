using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisibility : MonoBehaviour
{
   [SerializeField]
   private List<MeshRenderer>  _wallMesh;

   private float _showTime;
   
   private  float altha = 1f;

   
   private void Update()
   {
      if (Time.time > _showTime)
         Show();
   }

   public void HideFor(float seconds)
   {
      StartCoroutine(nameof(Hide));
      _showTime = Time.time + seconds;
   }
   
   private void Show()
   {
      foreach (var wallMesh in _wallMesh)
      {         
         wallMesh.material.color = new Color(1,1,1,altha);
         altha = 1f;
      }
   }   

   IEnumerator Hide()
   {
      while (altha > 0.5f)
      {
         foreach (var wallMesh in _wallMesh)
         {
            wallMesh.material.color = new Color(1, 1, 1, altha);
            altha -= Time.deltaTime;
            yield return altha;
         }
      }
   }
}
