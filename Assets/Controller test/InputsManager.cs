using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsManager : MonoBehaviour
{
   private ControlsCratos controls;
   [SerializeField] private Vector2 movementInput;
   public float HorisontalInput;
   public float VerticalInput;
   
   
   private void OnEnable()
   {
      if (controls == null)
      {
         controls = new ControlsCratos();

         controls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
      }
      
      controls.Enable();
   }

   private void OnDisable()
   {
      controls.Disable();
   }

   public void HandleAllInputs()
   {
      HandleMovementInput();
   }

   private void HandleMovementInput()
   {
      VerticalInput = movementInput.y;
      HorisontalInput = movementInput.x;
   }
}
