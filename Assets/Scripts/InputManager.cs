using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  PlayerControls playerControls;
  AnimatorManager animatorManager;
  
  public Vector2 movemementInput;
  private float moveAmount;
  public float verticalInput;
  public float horizontalInput;

  private void Awake()
  {
    animatorManager = GetComponent<AnimatorManager>();

  }
  private void OnEnable()
  
  {
     if (playerControls == null)
     {
        playerControls = new PlayerControls();
        playerControls.PlayerMovement.Movement.performed += i => movemementInput = i.ReadValue<Vector2>();
     }
     playerControls.Enable();
  }

   private void OnDisable()
   {
     playerControls.Disable();
   }
   public void HandleAllInputs()
   {
     HandleMovementInput();
     //HandleJumpingInput
     //HandleActionInput
   }
   private void HandleMovementInput()
   {
     verticalInput = movemementInput.y;
     horizontalInput = movemementInput.x;
     moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput)+ Mathf.Abs(verticalInput));
     animatorManager.UpdateAnimatorValues(0,moveAmount);
   }
}
