using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{  
   [SerializeField] private GameObject spherePrefab;
   [SerializeField] private bool _isSpawned;
   [SerializeField] private GameObject platform;
   private void Start()
   {
      spherePrefab.transform.position = platform.transform.position;
   }

   private void OnTriggerEnter(Collider collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         transform.Translate(0, -1, 0);
         if (!_isSpawned)
         {
            spherePrefab.transform.Translate(0, 2.5f, 0);
            Instantiate(spherePrefab);
            _isSpawned = true;
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      transform.Translate(0, 1, 0);
   }
}