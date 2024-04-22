using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
   public CinemachineVirtualCamera Cinemachine;
   private Rigidbody rb;
   [SerializeField] private float moveSpeed;
   private float _xInput, _zInput;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      Cinemachine = GetComponent<CinemachineVirtualCamera>();
   }

   private void Update()
   {
      _xInput = Input.GetAxis("Horizontal");
      _zInput = Input.GetAxis("Vertical");
      
      // if (Input.mouseScrollDelta.y > 0)
      // { 
      //    // Cinemachine.m_Lens.FieldOfView -= 1;
      //    Cinemachine.m_Lens.FieldOfView -= 1;
      // }
   }

   private void FixedUpdate()
   {
      float xVelocity = _xInput * moveSpeed;
      float zVelocity = _zInput * moveSpeed;

      rb.velocity = new Vector3(xVelocity, rb.velocity.y, zVelocity);
   }
}