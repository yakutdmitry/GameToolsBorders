using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    Animator animator;
    PlayerLocomotion playerLocomotion;
    public bool isInteracting;
   private void Awake()
   {
      animator = GetComponent<Animator>();
      inputManager = GetComponent<InputManager>();
      playerLocomotion = GetComponent<PlayerLocomotion>();
   }
   private void Update()
   {
      inputManager.HandleAllInputs();
   }
   private void FixedUpdate()
   {
      playerLocomotion.HandleAllMovement();
   }
   private void LateUpdate()
   {
      isInteracting = animator.GetBool("isInteracting");
   }
}
